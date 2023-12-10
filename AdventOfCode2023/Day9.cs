namespace AdventOfCode2023;

public static class Day9
{
    private enum PredictionType
    {
        Future, Historic
    }
    public static void Part1(string[] input) => input.GetPredictedValue(PredictionType.Future);
    public static void Part2(string[] input) => input.GetPredictedValue(PredictionType.Historic);

    private static void GetPredictedValue(this string[] input, PredictionType predictionType)
    {
        var sum = 0;
        foreach (var line in input)
        {
            var historicValues = line.Split(" ").Select(int.Parse).ToList();
            var predictedValues = new List<int>();
            while (true)
            {
                var initialValue = predictionType == PredictionType.Future ? historicValues.Last() : historicValues.First();
                predictedValues.Add(initialValue);
                if (historicValues.All(v => v == 0)) break;
                var newValues = new List<int>();
                
                for (var i = 0; i < historicValues.Count - 1; i++)
                {
                    var current = historicValues[i];
                    var next = historicValues[i + 1];
                    newValues.Add(next - current);
                }
                historicValues = newValues;
            }

            var predictedValue = predictedValues.Last();
            for (var i = predictedValues.Count - 2; i >= 0; i--)
            {
                predictedValue = predictedValues[i] + (predictionType == PredictionType.Future ? predictedValue : -predictedValue);
            }
            sum += predictedValue;
        }
        Console.WriteLine(sum);
    }
}