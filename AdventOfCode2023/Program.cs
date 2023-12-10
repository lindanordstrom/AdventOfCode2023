namespace AdventOfCode2023;

internal static class Program
{
    private static string[] TestInput => 
        """
        0 3 6 9 12 15
        1 3 6 10 15 21
        10 13 16 21 30 45
        """
            .Split("\n");

    private static string[] _realInput = InputLoader.Load(9, separator: "\n");

    private static void Main(string[] args)
    {
        Day9.Part1(_realInput);
        Day9.Part2(_realInput);
    }
}