using System.Numerics;

namespace AdventOfCode2023;

public static class Day13
{
    public static void Part1(string[] input)
    {
        var numberOfColumns = 0;
        var numberOfRows = 0;

        foreach (var patternString in input)
        {
            var pattern = patternString.Split("\n").ToList();
            var startIndex = 1;
            var leftIndex = 0;
            var rightIndex = 1;
            var rotated = false;

            while (true)
            {
                
                if (pattern[leftIndex] == pattern[rightIndex])
                {
                    leftIndex--;
                    rightIndex++;
                    
                    if (leftIndex < 0 || rightIndex == pattern.Count)
                    {
                        if (rotated)
                            numberOfColumns += startIndex;
                        else
                            numberOfRows += startIndex * 100 ;
                        break;
                    }
                }
                else
                {
                    startIndex++;
                    leftIndex = startIndex - 1;
                    rightIndex = startIndex;
                }
                
                if (rightIndex == pattern.Count)
                {
                    if (rotated) 
                        break;
                    pattern = RotatePattern(pattern);
                    rotated = true;
                    startIndex = 1;
                    leftIndex = 0;
                    rightIndex = 1;
                }
            }
        }
        Console.WriteLine(numberOfColumns + numberOfRows);
    }

    private static List<string> RotatePattern(List<string> pattern)
    {
        var newPattern = new List<string>();
                    
        for (int col = 0; col < pattern.First().Length; col++)
        {
            newPattern.Add("");
            for (int row = pattern.Count - 1; row >= 0; row--)
            {
                var value = pattern[row].ToCharArray()[col];
                newPattern[col] += value;
            }
        }
        return newPattern;
    }

    public static void Part2(string[] input)
    {
        // TODO
    }
}