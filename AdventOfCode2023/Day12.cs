namespace AdventOfCode2023;

public static class Day12
{
    public static void Part1(string[] input)
    {
        foreach (var line in input)
        {
            var content = line.Split(" ");
            var damageCount = content[1].Select(c => int.Parse(c.ToString()));
            var record = content[0];
            
            Console.WriteLine(record);
        }
    }
    
    // ???.### 1,1,3
    // .??..??...?##. 1,1,3
    // ?#?#?#?#?#?#?#? 1,3,1,6
    // ????.#...#... 4,1,1
    // ????.######..#####. 1,6,5
    // ?###???????? 3,2,1

    public static void Part2(string[] input)
    {
        Console.WriteLine("Part 2");
    }
}