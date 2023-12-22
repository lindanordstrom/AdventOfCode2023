namespace AdventOfCode2023;

internal static class Program
{
    private static string[] TestInput => 
        """
        #.##..##.
        ..#.##.#.
        ##......#
        ##......#
        ..#.##.#.
        ..##..##.
        #.#.##.#.
        
        #...##..#
        #....#..#
        ..##..###
        #####.##.
        #####.##.
        ..##..###
        #....#..#
        """
            .Split("\n\n");

    private static string[] _realInput = InputLoader.Load(13, separator: "\n\n");

    private static void Main(string[] args)
    {
        Day13.Part1(_realInput);
        Day13.Part2(TestInput);
    }
}