namespace AdventOfCode2023;

public static class Day4
{
    public static void Part1(string[] input)
    {
        var sum = 0;
        input.HandleMatchesPerGame((_, matchesCount) =>
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
        input.HandleMatchesPerGame((cardIndex, matchesCount) =>
        {
            Enumerable.Range(0, matchesCount)
                .ToList()
                .ForEach(i => cardCounts[cardIndex + i + 1] += cardCounts[cardIndex]);
        });
        Console.WriteLine(cardCounts.Sum() == 5539496);
    }

    private static void HandleMatchesPerGame(this string[] input, Action<int, int> closure)
    {
        foreach (var (line, cardIndex) in input.WithIndex())
        {
            var card = line
                .Remove(0, line.IndexOf(":") + 2)
                .Split(" | ");
            var winningNumbers = card[0].Split(" ");
            var ownNumbers = card[1].Split(" ");
            var matchesCount = winningNumbers.Intersect(ownNumbers).Count(num => num != "");
            
            closure(cardIndex, matchesCount);
        }
    }
}