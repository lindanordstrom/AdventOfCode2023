using System.Numerics;

namespace AdventOfCode2023;

public static class Day6
{
    public static void Part1(string[] input)
    {
        var times = input[0].GetValues();
        var distanceRecords = input[1].GetValues();
        Console.WriteLine(CalculateMarginOfErrors(times, distanceRecords));
    }

    public static void Part2(string[] input)
    {
        var times = new List<BigInteger> { BigInteger.Parse(string.Join("", input[0].GetValues())) };
        var distanceRecords = new List<BigInteger> { BigInteger.Parse(string.Join("", input[1].GetValues())) };
        Console.WriteLine(CalculateMarginOfErrors(times, distanceRecords));
    }
    
    private static List<BigInteger> GetValues(this string line)
    {
        return line
            .Remove(0, line.IndexOf(":") + 2)
            .Trim()
            .Split(" ")
            .Where(str => str != "")
            .Select(BigInteger.Parse)
            .ToList();
    }
    
    private static int CalculateMarginOfErrors(List<BigInteger> times, List<BigInteger> distanceRecords)
    {
        var marginOfError = 1;
        foreach (var (time, index) in times.WithIndex())
        {
            var waysToWin = 0;
            foreach (var holdTime in Extensions.BigRange(0, time))
            {
                var distance = holdTime * (time - holdTime);
                if (distance > distanceRecords[index])
                {
                    waysToWin++;
                }
            }
            marginOfError *= waysToWin;
        }
        return marginOfError;
    }
}