namespace AdventOfCode2023;

internal static class Program
{
    private static string[] TestInput => 
        """
        467..114..
        ...*......
        ..35..633.
        ......#...
        617*......
        .....+.58.
        ..592.....
        ......755.
        ...$.*....
        .664.598..
        """
            .Split("\n");

    private static string[] _realInput = InputLoader.Load(3);

    private static void Main(string[] args)
    {
        Day3.Part1(_realInput);
        Day3.Part2(_realInput);
    }
}