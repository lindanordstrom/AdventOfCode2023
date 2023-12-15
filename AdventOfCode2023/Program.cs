namespace AdventOfCode2023;

internal static class Program
{
    private static string[] TestInput => 
        """
        rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7
        """
            .Split(",");

    private static string[] _realInput = InputLoader.Load(15, separator: ",");

    private static void Main(string[] args)
    {
        Day15.Part1(_realInput);
        Day15.Part2(TestInput);
    }
}