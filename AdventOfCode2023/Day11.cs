namespace AdventOfCode2023;

public static class Day11
{
    public static void Part1(string[] input) => input.GetGalaxyDistances(1);
    public static void Part2(string[] input) => input.GetGalaxyDistances(999999);

    private static void GetGalaxyDistances(this string[] input, int expansionRate)
    {
        long sum = 0;
        var galaxies = new List<(long, long)>();
        
        var rowExpansion = 0;
        foreach (var (row, y) in input.WithIndex())
        {
            var occurrences = row.IndexesOf("#");
            if (occurrences.Count == 0)
            {
                rowExpansion += expansionRate;
                continue;
            }
            galaxies.AddRange(occurrences.Select(x => ((long)x, (long)(y + rowExpansion))));
        }
        
        for (var i = input.First().Length - 1; i > 0 ; i--)
        {
            if (galaxies.All(galaxy => galaxy.Item1 != i))
            {
                galaxies = galaxies.Select(galaxy =>
                {
                    if (galaxy.Item1 > i)
                    {
                        galaxy.Item1 += expansionRate;
                    }
                    return galaxy;
                }).ToList();
            }
        }

        for (var i = 0; i < galaxies.Count; i++)
        {
            for (var j = i + 1; j < galaxies.Count; j++)
            {
                var galaxy1 = galaxies[i];
                var galaxy2 = galaxies[j];
                var max1 = Math.Max(galaxy1.Item1, galaxy2.Item1);
                var min1 = Math.Min(galaxy1.Item1, galaxy2.Item1);
                var max2 = Math.Max(galaxy1.Item2, galaxy2.Item2);
                var min2 = Math.Min(galaxy1.Item2, galaxy2.Item2);
                sum += (max1 - min1) + (max2 - min2);
            }
        }
        Console.WriteLine(sum);
    }
}