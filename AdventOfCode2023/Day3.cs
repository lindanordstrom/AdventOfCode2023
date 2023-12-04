namespace AdventOfCode2023;

public static class Day3
{
    private static int _rows = 0;
    private static int _lineLength = 0;
    public static void Part1(string[] input)
    {
        var sum = 0;
        input.HandleAdjacentNumbersToSymbols(adjacentNumbers =>
        {
            sum += adjacentNumbers.Sum();
        });
        Console.WriteLine(sum);
    }

    public static void Part2(string[] input)
    {
        var sum = 0;
        input.HandleAdjacentNumbersToSymbols(adjacentNumbers =>
        {
            if (adjacentNumbers.Count == 2)
                sum += adjacentNumbers.First() * adjacentNumbers.Last();
        }, explicitCheck: "*");
        Console.WriteLine(sum);
    }

    private static void HandleAdjacentNumbersToSymbols(this string[] input, Action<HashSet<int>> closure, string? explicitCheck = null)
    {
        _rows = input.Length;
        _lineLength = input.First().Length;
        var numbersMap = GetNumbersAndPositions(input);
        
        foreach (var (line, lineIndex) in input.WithIndex())
        {
            foreach (var (character, charIndex) in line.WithIndex())
            {
                if (explicitCheck != null && char.ToString(character) != explicitCheck) continue;
                if (char.ToString(character) == "." || char.IsNumber(character)) continue;
                
                var adjacentNumbers = (lineIndex, charIndex).AdjacentNumbers(numbersMap);
                closure(adjacentNumbers);
            }
        }
    }
    
    private static HashSet<int> AdjacentNumbers(this (int, int) currentPosition, Dictionary<List<(int, int)>, int> numbersMap)
    {
        var adjacantNumbers = new HashSet<int>();
        foreach (var surroundingPosition in currentPosition.SurroundingPositions())
        {
            var numberAtPosition = numbersMap.FirstOrDefault(entry => entry.Key.Contains(surroundingPosition)).Value;
            if (numberAtPosition != 0)
                adjacantNumbers.Add(numberAtPosition);
        }

        return adjacantNumbers;
    }
    
    private static List<(int, int)> SurroundingPositions(this ( int lineIndex, int charIndex) currentPosition)
    {
        var surroundingNumbers = new List<(int, int)>();
        var lines = new List<int>();
        var chars = new List<int>();
        lines.Add(currentPosition.lineIndex);
        chars.Add(currentPosition.charIndex);
        if (currentPosition.lineIndex > 0)
            lines.Add(currentPosition.lineIndex - 1);
        if (currentPosition.lineIndex < _rows - 1)
            lines.Add(currentPosition.lineIndex + 1);
        if (currentPosition.charIndex > 0)
            chars.Add(currentPosition.charIndex - 1);
        if (currentPosition.charIndex < _lineLength - 1)
            chars.Add(currentPosition.charIndex + 1);

        foreach (var surroundingLine in lines) 
        foreach (var surroundingChar in chars)
            surroundingNumbers.Add((surroundingLine, surroundingChar));
        
        return surroundingNumbers;
    }

    private static Dictionary<List<(int, int)>, int> GetNumbersAndPositions(string[] input)
    {
        var numbers = new Dictionary<List<(int, int)>, int>();
        foreach (var (line, lineIndex) in input.WithIndex())
        {
            var currentNumber = 0;
            var currentNumberIndexes = new List<(int, int)>();
           
            foreach (var (character, charIndex) in line.WithIndex())
            {
                if (char.IsNumber(character))
                {
                    currentNumber = int.Parse($"{currentNumber}{character}");
                    currentNumberIndexes.Add((lineIndex, charIndex));

                    if (charIndex != line.Length - 1) continue;
                        numbers.Add(currentNumberIndexes, currentNumber);
                }
                else
                {
                    if (currentNumber == 0) continue;
                    numbers.Add(currentNumberIndexes, currentNumber);
                    currentNumber = 0;
                    currentNumberIndexes = new List<(int, int)>();
                }
            }
        }
        return numbers;
    }
}