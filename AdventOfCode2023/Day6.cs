using System.Numerics;
namespace AdventOfCode2023;

public static class Day6
{
    public static void Part1(string[] input) => input.CalculateMarginOfErrors();
    public static void Part2(string[] input) => input.CalculateMarginOfErrors(true);
    
    private static List<BigInteger> GetValues(this string line, bool mergeNumbers = false)
    {
        var values = line
            .Remove(0, line.IndexOf(":") + 2)
            .Trim()
            .Split(" ")
            .Where(str => str != "")
            .Select(BigInteger.Parse)
            .ToList();
        return mergeNumbers ? new List<BigInteger> { BigInteger.Parse(string.Join("", values)) } : values;
    }
    
    private static void CalculateMarginOfErrors(this IReadOnlyList<string> input, bool mergeNumbers = false)
    {
        var times = input[0].GetValues(mergeNumbers);
        var distanceRecords = input[1].GetValues(mergeNumbers);
        var marginOfError = 1;
        foreach (var (time, index) in times.WithIndex())
        {
            var waysToWin = Extensions.BigRange(0, time)
                .Select(holdTime => holdTime * (time - holdTime))
                .Count(distance => distance > distanceRecords[index]);
            marginOfError *= waysToWin;
        }
        Console.WriteLine(marginOfError);
    }
}