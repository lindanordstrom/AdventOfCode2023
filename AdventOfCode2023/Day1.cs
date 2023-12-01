using System.Diagnostics;

namespace AdventOfCode2023;

public static class Day1
{
    public static void Part1(string[] input)
    {
        var sum = 0;
        foreach (var line in input)
        {
            var charArray = line.ToCharArray();
            var first = charArray.First(char.IsDigit);
            var last = charArray.Last(char.IsDigit);
            sum += int.Parse($"{first}{last}");
        }
        Console.WriteLine(sum);
    }

    public static void Part2(string[] input) {
        var sum = 0;
        foreach (var line in input)
        {
            var numberArray = NumberArray(line);
            sum += int.Parse($"{numberArray.First()}{numberArray.Last()}");
        }
        Console.WriteLine(sum);
    }

    private static int[] NumberArray(string line)
    {
        line = line.AddNumber("0", "zero").AddNumber("1", "one").AddNumber("2", "two").AddNumber("3", "three").AddNumber("4", "four").AddNumber("5", "five").AddNumber("6", "six").AddNumber("7", "seven").AddNumber("8", "eight").AddNumber("9", "nine");
        var result = new List<int>();
        foreach (var character in line)
        {
            if (!char.IsDigit(character)) continue;
            var number = int.Parse(character.ToString());
            result.Add(number);
        }
        
        return result.ToArray();
    }
    
    private static string AddNumber(this string line, string number, string after)
    {
        if (!line.Contains(after)) return line;

        var indexes = line.AllIndexesOf(after).ToList();
        foreach (var index in indexes)
        {
            line = line.Insert(index + 2, number);
        }

        return line;
    }
    
    public static IEnumerable<int> AllIndexesOf(this string str, string searchstring)
    {
        int minIndex = str.IndexOf(searchstring);
        while (minIndex != -1)
        {
            yield return minIndex;
            minIndex = str.IndexOf(searchstring, minIndex + searchstring.Length);
        }
    }
}