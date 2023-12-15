namespace AdventOfCode2023;

public static class Day14
{
    public static void Part1(string[] input)
    {
        var platform = input.Select(s => s.ToCharArray()).ToList();
        TiltPlatform(ref platform, Direction.Up);
        Console.WriteLine(platform.GetSum());
    }
    
    public static void Part2(string[] input)
    {
        var platform = input.Select(s => s.ToCharArray()).ToList();
        var previousPlatforms = new List<List<char[]>>();
        
        for (var i = 0; i < 1000000000; i++)
        {
            TiltPlatform(ref platform, Direction.Up);
            TiltPlatform(ref platform, Direction.Left);
            TiltPlatform(ref platform, Direction.Down);
            TiltPlatform(ref platform, Direction.Right);
            
            if (previousPlatforms.ContainsPlatform(platform))
            {
                var index = previousPlatforms.FindIndex(previousPlatform => previousPlatform.SelectMany(row => row).SequenceEqual(platform.SelectMany(row => row)));
                var difference = i - index;
                var remaining = 1000000000 - i;
                var rest = remaining % difference;
                i += remaining - rest;
            }
            previousPlatforms.Add(platform.Select(row => row.ToArray()).ToList());
        }
        Console.WriteLine(platform.GetSum());
    }
    
    private static bool ContainsPlatform(this List<List<char[]>> previousPlatforms, List<char[]> platform)
    {
        return previousPlatforms.Any(previousPlatform => previousPlatform.SelectMany(row => row).SequenceEqual(platform.SelectMany(row => row)));
    }
    
    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    
    private static void TiltPlatform(ref List<char[]> platform, Direction direction)
    {
        var stopsDefault = direction is Direction.Up or Direction.Left ? -1 : direction is Direction.Down ? platform.Count : platform.First().Length;
        var stopsLength = direction is Direction.Up or Direction.Down ? platform.First().Length : platform.Count;
        var outerInitial = direction is Direction.Up or Direction.Left or Direction.Right ? 0 : platform.Count - 1;
        var outerLength = direction is Direction.Up or Direction.Left or Direction.Right ? platform.Count : -1;
        var innerInitial = direction is Direction.Right ? platform.First().Length - 1 : 0;
        var innerLength = direction is Direction.Right ? -1 : platform.First().Length;
        var outerCount = direction is Direction.Down ? -1 : 1;
        var innerCount = direction is Direction.Right ? -1 : 1;
        
        var currentStops = Enumerable.Repeat(stopsDefault, stopsLength).ToList();
        for (var outer = outerInitial; 
             direction is Direction.Down ? outer > outerLength : outerLength > outer; 
             outer += outerCount)
        {
            for (var inner = innerInitial; 
                 direction is Direction.Right ? inner > innerLength : innerLength > inner; 
                 inner += innerCount)
            {
                var current = platform[outer][inner];
                var index = direction is Direction.Up or Direction.Down ? inner : outer;
                var value = direction is Direction.Up or Direction.Down ? outer : inner;
                
                if (current == 'O')
                {
                    currentStops[index] += direction is Direction.Up or Direction.Left ? 1 : -1;
                    var row = direction is Direction.Up or Direction.Down ? currentStops[inner] : outer;
                    var column = direction is Direction.Up or Direction.Down ? inner : currentStops[outer];
                    platform[outer][inner] = '.';
                    platform[row][column] = 'O';
                }
                else if (current == '#')
                {
                    currentStops[index] = value;
                }
            }
        }
    }
    
    private static int GetSum(this List<char[]> platform)
    {
        var sum = 0;
        foreach (var (row, y) in platform.WithIndex())
        {
            var multiplier = platform.Count - y;
            sum += row.Count(c => c == 'O') * multiplier;
        }
        return sum;
    }
}