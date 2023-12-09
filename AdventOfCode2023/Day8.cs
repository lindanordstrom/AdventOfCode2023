using System.Numerics;

namespace AdventOfCode2023;

public static class Day8
{
    public static void Part1(string[] input) => input.StepsNeeded("AAA", "ZZZ");
    public static void Part2(string[] input) => input.StepsNeeded("A", "Z");

    private static void StepsNeeded(this string[] input, string start, string goal)
    {
        var orderIndex = 0;
        var steps = 0;
        var stepsPerNode = new List<BigInteger>();
        var order = input.First();
        var nodesMapping = input.Last()
            .Split("\n")
            .ToDictionary(line => line[..3], line => new[] { line[7..10], line[12..15] });
        var currentNodes = nodesMapping
            .Where(entry => entry.Key.EndsWith(start))
            .Select(entry => entry.Key)
            .ToList();
        
        while (true)
        {
            foreach (var (currentNode, index) in currentNodes.ToList().WithIndex())
            {
                var nextNode = order.ToCharArray()[orderIndex] == 'L' ? 0 : 1;
                currentNodes[index] = nodesMapping[currentNode][nextNode];
            }
            steps++;
            orderIndex = orderIndex >= order.Length - 1 ? 0 : orderIndex + 1;
            currentNodes.RemoveAll(n =>
            {
                if (!n.EndsWith(goal)) return false;
                stepsPerNode.Add(steps);
                return true;

            });
            
            if (currentNodes.Count == 0 || currentNodes.All(n => n.EndsWith(goal))) break;
        }
        Console.WriteLine(stepsPerNode.Aggregate(LowestCommonMultiple));
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