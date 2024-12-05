using AdventOfCode2024;

namespace AdventOfCode2024Test;

public class HistorianHysteriaTests
{
    [Fact]
    public void SolveForDistanceTest()
    {
        var hysteria = new HistorianHysteria();

        var distance = hysteria.SolveForDistance();

        Console.WriteLine($"Distance: {distance}");

        Assert.Equal(2066446, distance);
    }

    [Fact]
    public void SolveForSimilarityTest()
    {
        var hysteria = new HistorianHysteria();

        var similaritySum = hysteria.SolveForSimilarity();

        Console.WriteLine($"Similarity sum: {similaritySum}");

        Assert.Equal(24931009, similaritySum);
    }
}
