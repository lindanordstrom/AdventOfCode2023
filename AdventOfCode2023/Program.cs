namespace AdventOfCode2023;

internal static class Program
{
    private static string[] TestInput => 
        """
        O....#....
        O.OO#....#
        .....##...
        OO.#O....O
        .O.....O#.
        O.#..O.#.#
        ..O..#O..O
        .......O..
        #....###..
        #OO..#....
        """
            .Split("\n");

    private static string[] _realInput = InputLoader.Load(14, separator: "\n");

    private static void Main(string[] args)
    {
        Day14.Part1(_realInput);
        Day14.Part2(_realInput);
    }
}