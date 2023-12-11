using System.Numerics;

namespace AdventOfCode2023;

public static class Extensions
{ 
    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)       
            => self.Select((item, index) => (item, index));
    
    public static IEnumerable<BigInteger> BigRange(BigInteger start, BigInteger count)
    {
        var limit = start + count;

        while (start < limit)
        {
            yield return start;
            start++;
        }
    }
    
    public static List<int> IndexesOf(this string str, string value) {
        var indexes = new List<int>();
        for (var index = 0;; index += value.Length) {
            index = str.IndexOf(value, index);
            if (index == -1)
                return indexes;
            indexes.Add(index);
        }
    }
}