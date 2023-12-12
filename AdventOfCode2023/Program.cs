namespace AdventOfCode2023;

internal static class Program
{
    private static string[] TestInput => 
        """
        -L|F7
        7S-7|
        L|7||
        -L-J|
        L|-JF
        """
            .Split("\n");

    private static string[] _realInput = InputLoader.Load(10, separator: "\n");

    private static void Main(string[] args)
    {
        Day10.Part1(_realInput);
        Day10.Part2(TestInput);
    }
}