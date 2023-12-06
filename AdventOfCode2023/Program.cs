namespace AdventOfCode2023;

internal static class Program
{
    private static string[] TestInput => 
        """
        Time:      7  15   30
        Distance:  9  40  200
        """
            .Split("\n");

    private static string[] _realInput = InputLoader.Load(6, separator: "\n");

    private static void Main(string[] args)
    {
        Day6.Part1(_realInput);
        Day6.Part2(_realInput);
    }
}