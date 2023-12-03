namespace AdventOfCode2023;

public static class InputLoader
{
    public static string[] Load(int day, string separator = "\n")
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Cookie", $"session={Private.sessionId}");
        var result = client.GetStringAsync($"https://adventofcode.com/2023/day/{day}/input").Result.Split(separator);
        
        if (result.Last() == "")
            result = result[..^1];
        
        return result;
    }
}