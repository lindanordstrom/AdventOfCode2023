namespace AdventOfCode2023;

public static class Day10
{
    public static void Part1(string[] input)
    {
        var steps = 0;
        var start = (x: 0, y: 0);
        foreach (var (line, y) in input.WithIndex())
        {
            var x = line.IndexOf("S");
            if (x == -1) continue;
            start = (x, y);
            break;
        }
        
        var currentIndex = start;
        var previousIndex = (-1, -1);
        while (true)
        {
            var currentValue = input.Value(currentIndex);
            var above = (currentIndex.x, currentIndex.y - 1);
            var below = (currentIndex.x, currentIndex.y + 1);
            var left = (currentIndex.x - 1, currentIndex.y);
            var right = (currentIndex.x + 1, currentIndex.y);
            
            if (above != previousIndex && input.Value(above) is "|" or "7" or "F" or "S" && currentValue is "|" or "J" or "L" or "S")
            {
                previousIndex = currentIndex;
                currentIndex = (currentIndex.x, currentIndex.y - 1);
            }
            else if (below != previousIndex && input.Value(below) is "|" or "J" or "L" or "S" && currentValue is "|" or "7" or "F" or "S")
            {
                previousIndex = currentIndex;
                currentIndex = (currentIndex.x, currentIndex.y + 1);
            }
            else if (left != previousIndex && input.Value(left) is "-" or "F" or "L" or "S" && currentValue is "-" or "7" or "J" or "S")
            {
                previousIndex = currentIndex;
                currentIndex = (currentIndex.x - 1, currentIndex.y);
            }
            else if (right != previousIndex && input.Value(right) is "-" or "7" or "J" or "S" && currentValue is "-" or "F" or "L" or "S")
            {
                previousIndex = currentIndex;
                currentIndex = (currentIndex.x + 1, currentIndex.y);
            }
            steps++;
            Console.WriteLine(currentIndex);
            if (currentIndex == start)
            {
                Console.WriteLine(steps / 2);
                break;
            }
        }
    }

    public static void Part2(string[] input)
    {
        // TODO
    }
    
    private static string Value(this string[] input, (int x, int y) index)
    {
        if (index.x < 0 || index.y < 0 || index.x >= input[0].Length || index.y >= input.Length) return "";
        return input[index.y][index.x].ToString();
    }
}