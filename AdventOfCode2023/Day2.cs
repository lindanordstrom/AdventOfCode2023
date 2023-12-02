namespace AdventOfCode2023;

public static class Day2
{
    public static void Part1(string[] input)
    {
        var sum = 0;
        foreach (var (line, gameIndex) in input.WithIndex())
        {
            var roundWasSuccessful = true;

            line.GetGames()
                .GetValuesPerGame((color, amount) =>
                {
                    if (color == "red" && amount > 12 ||
                        color == "green" && amount > 13 ||
                        color == "blue" && amount > 14)
                    {
                        roundWasSuccessful = false;
                    }
                });

            sum += roundWasSuccessful ? gameIndex + 1 : 0;
        }

        Console.WriteLine(sum);
    }

    public static void Part2(string[] input)
    {
        var sum = 0;
        foreach (var line in input)
        {
            var colorDictionary = new Dictionary<string, int>
            {
                { "red", 0 },
                { "green", 0 },
                { "blue", 0 }
            };

            line.GetGames()
                .GetValuesPerGame((color, amount) =>
                {
                    if (amount > colorDictionary[color])
                    {
                        colorDictionary[color] = amount;
                    }
                });

            var power = colorDictionary.Aggregate(1, (current, color) => current * color.Value);
            sum += power;
        }

        Console.WriteLine(sum);
    }
    
    private static string[] GetGames(this string line)
    {
        return line
            .Remove(0, line.IndexOf(":") + 2)
            .Split("; ");
    }

    private static void GetValuesPerGame(this string[] games, Action<string, int> closure)
    {
        foreach (var game in games)
        {
            var cubes = game.Split(", ");
            foreach (var cube in cubes)
            {
                var cubeValues = cube.Split(" ");
                var amount = int.Parse(cubeValues[0]);
                var color = cubeValues[1];

                closure(color, amount);
            }

        }
    }
}