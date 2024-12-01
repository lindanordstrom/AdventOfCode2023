using System.Numerics;

namespace AdventOfCode2023;

public static class Day5
{
    public static void Part1(string[] input)
    {
        BigInteger? lowestLocationNumber = null;
        
        var maps = input.GetMaps();
        var seeds = maps.First().First();
        maps.RemoveAt(0);

        foreach (var seed in seeds)
        {
            var seedValue = seed;
            foreach (var map in maps)
            {
                foreach (var ranges in map)
                {
                    var rangeStart = ranges[1];
                    var rangeEnd = rangeStart + ranges[2] - 1;
                    if (!seedValue.IsInRange(rangeStart, rangeEnd)) continue;
                    seedValue += ranges[0] - rangeStart;
                    break;
                }
            }
            lowestLocationNumber = BigInteger.Min(lowestLocationNumber ?? seedValue, seedValue);
        }
        Console.WriteLine(lowestLocationNumber);
    }
    
    public static void Part2(string[] input)
    {
        BigInteger? lowestLocationNumber = null;
        
        var maps = input.GetMaps();
        var seeds = maps.First().First();
        maps.RemoveAt(0);

        for (var i = 0; i < seeds.Count; i += 2)
        {
        }
        
        // foreach (var seed in Extensions.BigRange(seeds[i], seeds[i + 1]))
        // {
        //     var seedValue = seed;
        //     foreach (var map in maps)
        //     {
        //         foreach (var ranges in map)
        //         {
        //             var rangeStart = ranges[1];
        //             var rangeEnd = rangeStart + ranges[2] - 1;
        //             if (!seedValue.IsInRange(rangeStart, rangeEnd)) continue;
        //             seedValue += ranges[0] - rangeStart;
        //             break;
        //         }
        //     }
        //
        //     lowestLocationNumber = BigInteger.Min(lowestLocationNumber ?? seedValue, seedValue);
        // }

        Console.WriteLine(lowestLocationNumber);
    }
    
    private static List<IEnumerable<List<BigInteger>>> GetMaps(this string[] input)
    {
        return input.Select(line => line
            .Remove(0, line.IndexOf(":") + 2)
            .Split("\n")
            .Select(values => values
                .Split(" ")
                .Select(BigInteger.Parse)
                .ToList())
        ).ToList();
    }
    
    private static bool IsInRange(this BigInteger value, BigInteger start, BigInteger end)
    {
        return value >= start && value <= end;
    }
}