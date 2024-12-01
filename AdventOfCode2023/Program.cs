namespace AdventOfCode2023;

internal static class Program
{
    private static string[] TestInput => 
        """
        .|...\....
        |.-.\.....
        .....|-...
        ........|.
        ..........
        .........\
        ..../.\\..
        .-.-/..|..
        .|....-|.\
        ..//.|....
        """
            .Split("\n");

    private static string[] _realInput = InputLoader.Load(16, separator: "\n");

    private static void Main(string[] args)
    {
        Day16.Part1(TestInput);
        Day16.Part2(TestInput);
    }
}