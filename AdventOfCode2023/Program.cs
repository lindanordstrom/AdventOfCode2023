namespace AdventOfCode2023;

internal static class Program
{
    private static string[] TestInput => 
        """
        32T3K 765
        T55J5 684
        KK677 28
        KTJJT 220
        QQQJA 483
        """
            .Split("\n");

    private static string[] _realInput = InputLoader.Load(7, separator: "\n");

    private static void Main(string[] args)
    {
        Day7.Part1(_realInput);
        Day7.Part2(_realInput);
    }
}