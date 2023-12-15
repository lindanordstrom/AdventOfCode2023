namespace AdventOfCode2023;

public static class Day15
{
    public static void Part1(string[] input)
    {
        var sum = input.Sum(step => step.Hash());
        Console.WriteLine(sum);
    }

    public static void Part2(string[] input)
    {
        var boxes = new List<(string, int)>[256];
        foreach (var step in input)
        {
            string label;
            char operation;
            var focalLength = 0;
            
            if (step.Last() == '-')
            {
                label = step[..^1];
                operation = '-';
            } else
            {
                label = step[..^2];
                operation = '=';
                focalLength = int.Parse(step.Last().ToString());
            }
            
            var box = label.Hash();

            boxes[box] ??= new List<(string, int)>();

            if (operation == '-')
                boxes[box].RemoveAll(tuple => tuple.Item1 == label);
            else
            {
                var index = boxes[box].FindIndex(tuple => tuple.Item1 == label);
                if (index == -1)
                    boxes[box].Add((label, focalLength));
                else
                    boxes[box][index] = (label, focalLength);
            }
        }

        var sum = 0;
        foreach (var (box, boxIndex) in boxes.WithIndex())
        {
            if (box == null) continue;
            foreach (var (slot, slotIndex) in box.WithIndex())
                sum += (boxIndex + 1) * (slotIndex + 1) * slot.Item2;
        }
        Console.WriteLine(sum);
    }
    
    private static int Hash(this string line)
    {
        return line.Aggregate(0, (current, c) =>
        {
            current += c;
            current *= 17;
            current %= 256;
            return current;
        });
    }
}