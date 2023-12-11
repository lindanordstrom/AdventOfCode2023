namespace AdventOfCode2023;

internal static class Program
{
    private static string[] TestInput => 
        """
        ...#......
        .......#..
        #.........
        ..........
        ......#...
        .#........
        .........#
        ..........
        .......#..
        #...#.....
        """
            .Split("\n");

    private static string[] _realInput = InputLoader.Load(11, separator: "\n");

    private static void Main(string[] args)
    {
        Day11.Part1(_realInput);
        Day11.Part2(_realInput);
    }
}