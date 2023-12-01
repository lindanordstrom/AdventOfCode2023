namespace AdventOfCode2023;

public static class Day1
{
    public static void Part1(string[] input)
    {
        var sum = input.Sum(line => line.MergeFirstAndLastNumber());
        Console.WriteLine(sum);
    }

    public static void Part2(string[] input) {
        var sum = 0;
        foreach (var line in input)
        {
            sum += line
                .AddNumber("0", "zero")
                .AddNumber("1", "one")
                .AddNumber("2", "two")
                .AddNumber("3", "three")
                .AddNumber("4", "four")
                .AddNumber("5", "five")
                .AddNumber("6", "six")
                .AddNumber("7", "seven")
                .AddNumber("8", "eight")
                .AddNumber("9", "nine")
                .MergeFirstAndLastNumber();
        }
        Console.WriteLine(sum);
    }
    
    private static int MergeFirstAndLastNumber(this string line)
    {
        var charArray = line.ToCharArray();
        var first = charArray.First(char.IsDigit);
        var last = charArray.Last(char.IsDigit);
        return int.Parse($"{first}{last}");
    }
    
    private static string AddNumber(this string line, string number, string intoString)
    {
        if (!line.Contains(intoString)) return line;

        var indexes = line.AllIndexesOf(intoString);
        foreach (var index in indexes)
        {
            line = line.Insert(index + 2, number);
        }

        return line;
    }
    
    private static List<int> AllIndexesOf(this string line, string searchstring)
    {
        var result = new List<int>();
        var minIndex = line.IndexOf(searchstring);
        
        while (minIndex != -1)
        {
            result.Add(minIndex);
            minIndex = line.IndexOf(searchstring, minIndex + searchstring.Length);
        }

        return result;
    }
}