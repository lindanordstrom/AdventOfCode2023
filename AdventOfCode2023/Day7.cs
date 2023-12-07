namespace AdventOfCode2023;

public static class Day7
{
    private enum HandType
    {
        FiveOfAKind, FourOfAKind, FullHouse, ThreeOfAKind, TwoPair, OnePair, HighCard
    }
    
    public static void Part1(string[] input) => CalculateWinnings(input);
    public static void Part2(string[] input) => CalculateWinnings(input, jokerIncluded: true);

    private static void CalculateWinnings(IReadOnlyCollection<string> input, bool jokerIncluded = false)
    {
        var totalWinnings = 0;
        var rank = input.Count;
        var game = new Dictionary<HandType, IEnumerable<string>>
        {
            { HandType.FiveOfAKind, Array.Empty<string>() }, 
            { HandType.FourOfAKind, Array.Empty<string>() }, 
            { HandType.FullHouse, Array.Empty<string>() }, 
            { HandType.ThreeOfAKind, Array.Empty<string>() }, 
            { HandType.TwoPair, Array.Empty<string>() }, 
            { HandType.OnePair, Array.Empty<string>() }, 
            { HandType.HighCard, Array.Empty<string>() }
        };

        foreach (var hand in input)
        {
            var cards = hand[..5];
            var type = GetHandType(cards, jokerIncluded);
            game[type] = game[type].Append(hand);
        }

        foreach (var type in game)
        {
            var hands = type.Value.ToArray();
            Array.Sort(hands, (a, b) =>
            {
                var handA = IntValuesForHand(a, jokerIncluded);
                var handB = IntValuesForHand(b, jokerIncluded);
                for (var i = 0; i < handA.Length; i++)
                {
                    if (handA[i] == handB[i]) continue;
                    return handB[i] - handA[i];
                }
                return 0;
            });

            foreach (var hand in hands)
            {
                totalWinnings += rank * int.Parse(hand.Split(" ").Last());
                rank--;
            }
        }
        Console.WriteLine(totalWinnings);
    }

    private static HandType GetHandType(string cards, bool jokerIncluded = false)
    {
        var sortedHand = cards
            .GroupBy(c => c)
            .OrderByDescending(c => c.Count())
            .ToList();

        if (jokerIncluded)
        {
            var mostCommonCard = sortedHand.First().Key;
            if (mostCommonCard == 'J' && sortedHand.Count > 1)
            {
                mostCommonCard = sortedHand[1].Key;
            }
            return GetHandType(cards.Replace("J", mostCommonCard.ToString()));
        }

        return sortedHand.First().Count() switch
        {
            5 => HandType.FiveOfAKind,
            4 => HandType.FourOfAKind,
            3 => sortedHand.Count == 2 ? HandType.FullHouse : HandType.ThreeOfAKind,
            2 => sortedHand.Count == 3 ? HandType.TwoPair : HandType.OnePair,
            _ => HandType.HighCard
        };
    }
    
    private static int[] IntValuesForHand(string hand, bool jokerIncluded = false)
    {
        return hand
            .Split(" ")
            .First()
            .Select(c => GetValueForCard(c, jokerIncluded))
            .ToArray();
    }
    
    private static int GetValueForCard(char card, bool jokerIncluded)
    {
        return card switch
        {
            'A' => 14,
            'K' => 13,
            'Q' => 12,
            'J' => jokerIncluded ? 1 : 11,
            'T' => 10,
            _ => int.Parse(card.ToString())
        };
    }
}