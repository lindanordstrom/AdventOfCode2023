using System.Numerics;
using System.Runtime.InteropServices.JavaScript;

namespace AdventOfCode2023;

public static class Day8
{
    public static void Part1(string[] input) => input.StepsNeeded("AAA", "ZZZ");
    public static void Part2(string[] input) => input.StepsNeeded("A", "Z");

    private static void StepsNeeded(this string[] input, string start, string goal)
    {
        var orderIndex = 0;
        var resetCount = 0;
        var order = input.First();
        var network = input.Last()
            .Split("\n")
            .ToDictionary(line => line[..3], line => new[] { line[7..10], line[12..15] });
        var currentNodes = network
            .Where(entry => entry.Key.EndsWith(start))
            .Select(entry => entry.Key)
            .ToList();
        var resetTimes = new List<BigInteger>();
        
        while (true)
        {
            foreach (var (currentNode, index) in currentNodes.ToList().WithIndex())
            {
                var nextNode = order.ToCharArray()[orderIndex] == 'L' ? 0 : 1;
                currentNodes[index] = network[currentNode][nextNode];
            }
            
            var shouldResetOrder = orderIndex >= order.Length - 1;
            resetCount = shouldResetOrder ? resetCount + 1 : resetCount;
            orderIndex = shouldResetOrder ? 0 : orderIndex + 1;

            if (currentNodes.Any(n => n.EndsWith(goal)))
            {
                currentNodes
                    .Where(n => n.EndsWith(goal))
                    .ToList()
                    .ForEach(node => resetTimes.Add(resetCount));
                currentNodes.RemoveAll(n => n.EndsWith(goal));
            }
            
            if (currentNodes.Count == 0 || currentNodes.All(n => n.EndsWith(goal))) break;
        }

        var lcmOfResetTimes = resetTimes.Aggregate((a, b) => LowestCommonMultiple(a, b));
        
        Console.WriteLine(lcmOfResetTimes * order.Length);
    }

    private static BigInteger LowestCommonMultiple(BigInteger a, BigInteger b)
    {
        var num1 = a > b ? a : b;
        var num2 = a < b ? a : b;
        for (var i = 1; i <= num2; i++)
        {
            if (num1 * i % num2 == 0)
            {
                return i * num1;
            }
        }
        return num2;
    }
}