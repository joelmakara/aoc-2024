namespace AdventOfCode2024;

public class HistorianHysteria
{
    public int SolveForDistance()
    {
        var input = File.ReadAllLines(@"..\..\..\input\1\input.txt");

        var locationIds1 = new List<int>();
        var locationIds2 = new List<int>();

        foreach (var line in input)
        {
            var locationIds = line.Split([' '], StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .ToList();
            locationIds1.Add(locationIds[0]);
            locationIds2.Add(locationIds[1]);
        }

        locationIds1.Sort();
        locationIds2.Sort();

        var totalDistance = 0;
        for (int i = 0; i < locationIds1.Count; i++)
        {
            totalDistance += Math.Abs(locationIds1[i] - locationIds2[i]);
        }

        return totalDistance;
    }

    public int SolveForSimilarity()
    {
        var input = File.ReadAllLines(@"..\..\..\input\1\input.txt");

        var locationIds1 = new List<int>();
        var locationIds2 = new List<int>();

        foreach (var line in input)
        {
            var locationIds = line.Split([' '], StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .ToList();
            locationIds1.Add(locationIds[0]);
            locationIds2.Add(locationIds[1]);
        }

        var similarity = new List<int>();
        for (int i = 0; i < locationIds1.Count; i++)
        {
            var occurences = locationIds2.Count(x => x == locationIds1[i]);
            similarity.Add(locationIds1[i] * occurences);
        }

        return similarity.Sum();
    }
}
