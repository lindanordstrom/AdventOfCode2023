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
}