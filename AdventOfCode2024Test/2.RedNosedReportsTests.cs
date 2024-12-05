using AdventOfCode2024;

namespace AdventOfCode2024Test;

public class RedNosedReportsTests
{
    [Fact]
    public void SafeReportCountTest()
    {
        var reports = new RedNosedReports();
        var safeReportCount = reports.SafeReportCount();
        Console.WriteLine($"Safe report count: {safeReportCount}");
        Assert.Equal(407, safeReportCount);
    }

    [Fact]
    public void SafeReportWithDampnerCount()
    {
        var reports = new RedNosedReports();
        var safeReportCount = reports.SafeReportWithDampnerCount();
        Console.WriteLine($"Safe report count with dampner: {safeReportCount}");
        Assert.Equal(500, safeReportCount);
    }
}
