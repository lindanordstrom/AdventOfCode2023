namespace AdventOfCode2023;

public static class Day15
{
    public static void Part1(string[] input)
    {
        var sum = input.Sum(step => step.Aggregate(0, (current, c) =>
        {
            current += c;
            current *= 17;
            current %= 256;
            return current;
        }));
        Console.WriteLine(sum);
    }

    public static void Part2(string[] input)
    {
        // TODO
    }
}