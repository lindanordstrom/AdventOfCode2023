namespace AdventOfCode2023;

public static class Day4
{
    public static void Part1(string[] input)
    {
        var sum = 0;
        input.HandleMatchesPerGame((index, matchesCount) =>
        {
            var points = 0;
            Enumerable.Range(0, matchesCount)
                .ToList()
                .ForEach(_ => points += points == 0 ? 1 : points);
            sum += points;
        });
        Console.WriteLine(sum == 21821);
    }

    public static void Part2(string[] input)
    {
        var cardCounts = Enumerable.Repeat(1, input.Length).ToArray();
        input.HandleMatchesPerGame((index, matchesCount) =>
        {
            Enumerable.Range(0, matchesCount)
                .ToList()
                .ForEach(i => cardCounts[index + i + 1] += cardCounts[index]);
        });
        Console.WriteLine(cardCounts.Sum() == 5539496);
    }

    private static void HandleMatchesPerGame(this string[] input, Action<int, int> closure)
    {
        foreach (var (line, index) in input.WithIndex())
        {
            var card = line
                .Remove(0, line.IndexOf(":") + 2)
                .Split(" | ");
            var winningNumbers = card[0].Split(" ");
            var ownNumbers = card[1].Split(" ");
            var matchesCount = winningNumbers.Intersect(ownNumbers).Count(num => num != "");
            
            closure(index, matchesCount);
        }
    }
}