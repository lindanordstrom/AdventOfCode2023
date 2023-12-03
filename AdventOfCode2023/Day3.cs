namespace AdventOfCode2023;

public static class Day3
{
    public static void Part1(string[] input)
    {
        var sum = 0;
        foreach (var (line, lineIndex) in input.WithIndex())
        {
            var currentNumber = 0;
            var currentNumberIsAdjacentSymbol = false;
            foreach (var (character, charIndex) in line.WithIndex())
            {
                if (char.IsNumber(character))
                {
                    currentNumber = int.Parse($"{currentNumber}{character}");
                    var adjacentChars = new List<char>();
                    if (charIndex > 0)
                        adjacentChars.Add(line[charIndex - 1]);
                    if (charIndex < line.Length - 1)
                        adjacentChars.Add(line[charIndex + 1]);
                    if (lineIndex > 0)
                    {
                        var previousLine = input[lineIndex - 1];
                        adjacentChars.Add(previousLine[charIndex]);
                        if (charIndex > 0)
                            adjacentChars.Add(previousLine[charIndex - 1]);
                        if (charIndex < line.Length - 1)
                            adjacentChars.Add(previousLine[charIndex + 1]);
                    }
                    if (lineIndex < input.Length - 1)
                    {
                        var nextLine = input[lineIndex + 1];
                        adjacentChars.Add(nextLine[charIndex]);
                        if (charIndex > 0)
                            adjacentChars.Add(nextLine[charIndex - 1]);
                        if (charIndex < line.Length - 1)
                            adjacentChars.Add(nextLine[charIndex + 1]);
                    }
                    
                    if (adjacentChars.Any(adjacentChar => !char.IsNumber(adjacentChar) && adjacentChar.ToString() != "."))
                    {
                        currentNumberIsAdjacentSymbol = true;
                    }

                    if (charIndex != line.Length - 1) continue;
                    
                    if (currentNumberIsAdjacentSymbol)
                        sum += currentNumber;
                }
                else
                {
                    if (currentNumberIsAdjacentSymbol)
                        sum += currentNumber;
                    currentNumber = 0;
                    currentNumberIsAdjacentSymbol = false;
                }
            }
        }
        Console.WriteLine(sum);
    }

    public static void Part2(string[] input)
    {
        var sum = 0;
        var numbers = GetNumbersAndPositions(input);
        
        foreach (var (line, lineIndex) in input.WithIndex())
        {
            foreach (var (character, charIndex) in line.WithIndex())
            {
                if (char.ToString(character) != "*") continue;
                
                var surroundingNumbers = new List<(int, int)>();
                var lines = new List<int>();
                var chars = new List<int>();
                lines.Add(lineIndex);
                chars.Add(charIndex);
                if (lineIndex > 0)
                    lines.Add(lineIndex - 1);
                if (lineIndex < input.Length - 1)
                    lines.Add(lineIndex + 1);
                if (charIndex > 0)
                    chars.Add(charIndex - 1);
                if (charIndex < line.Length - 1)
                    chars.Add(charIndex + 1);

                foreach (var surroundingLine in lines) 
                    foreach (var surroundingChar in chars)
                        surroundingNumbers.Add((surroundingLine, surroundingChar));
                    
                var uniqueList = new HashSet<int>();
                    
                foreach (var surroundingNumber in surroundingNumbers)
                    if (numbers.NumberAtPosition(surroundingNumber) is int number && number != 0)
                        uniqueList.Add(number);
                    

                if (uniqueList.Count == 2)
                    sum += uniqueList.First() * uniqueList.Last();
                
            }
        }
        Console.WriteLine(sum);
    }

    private static int? NumberAtPosition(this Dictionary<List<(int, int)>, int> numbers, (int, int) position)
    {
        return numbers.FirstOrDefault(number => number.Key.Contains(position)).Value;
    }
    
    public static Dictionary<List<(int, int)>, int> GetNumbersAndPositions(string[] input)
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