using BenchmarkDotNet.Attributes;

namespace BenchmarckHashSet;

[RankColumn]
public class BenchmarkStringHashSet
{
    List<string> expectedStrings = new List<string>();

    HashSet<string> stringsHashSet = new HashSet<string>();
    string[] stringArray = new string[0];

    [Params(10000, 15000, 20000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        stringArray = new string[Count];

        for (int i = 0; i < Count; i++)
        {
            string newString = GetRandomString(10);
            stringsHashSet.Add(newString);
            expectedStrings.Add(newString);
            stringArray[i] = newString;
        }
    }

    [Benchmark(Description = "Contains string in HashSet")]
    public void ContainsStringInHashSet()
    {
        foreach (string item in expectedStrings)
        {
            stringsHashSet.Contains(item); 
        }
    }
    [Benchmark(Description = "Contains string in Array")]
    public void ContainsStringInArray()
    {
        foreach (string item in expectedStrings)
        {
            stringArray.Contains(item);
        }
    }

    public string GetRandomString(int length)
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
