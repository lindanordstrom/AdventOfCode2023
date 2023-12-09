namespace AdventOfCode2023;

internal static class Program
{
    private static string[] TestInput => 
        """
        LR
        
        11A = (11B, XXX)
        11B = (XXX, 11Z)
        11Z = (11B, XXX)
        22A = (22B, XXX)
        22B = (22C, 22C)
        22C = (22Z, 22Z)
        22Z = (22B, 22B)
        XXX = (XXX, XXX)
        """
            .Split("\n\n");

    private static string[] _realInput = InputLoader.Load(8, separator: "\n\n");

    private static void Main(string[] args)
    {
        Day8.Part1(_realInput);
        Day8.Part2(_realInput);
    }
}