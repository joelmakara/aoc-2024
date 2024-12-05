
namespace AdventOfCode2024;

public class RedNosedReports
{
    public int SafeReportCount()
    {
        var reportList = File.ReadAllLines(@"..\..\..\input\2\input.txt").ToList();

        var safeReportCount = 0;

        reportList.ForEach(report =>
        {
            var levels = report.Split([' '], StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

            var (isReportSafe, _) = IsReportSafe(levels);
            
            if (isReportSafe)
            {
                safeReportCount++;
            }
        });

        return safeReportCount;
    }

    public int SafeReportWithDampnerCount()
    {
        var reportList = File.ReadAllLines(@"..\..\..\input\2\input.txt").ToList();

        var safeReportCount = 0;

        reportList.ForEach(report =>
        {
            var levels = report.Split([' '], StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

            if (IsReportSafeWithTolerance(levels))
            {
                safeReportCount++;
            }
        });

        return safeReportCount;
    }

    private bool IsReportSafeWithTolerance(List<int> levels)
    {
        var (isSafe, unsafeIndex) = IsReportSafe(levels);

        if (!isSafe)
        {
            levels.RemoveAt(unsafeIndex);
            (isSafe,_) = IsReportSafe(levels);
        }        

        return isSafe;
    }


    private (bool, int) IsReportSafe(List<int> levels)
    {
        var isSafe = true;
        var unsafeIndex = 0;
        var isDescending = levels[0] > levels[1];

        for (int i = 0; i < levels.Count - 1; i++)
        {
            var currentLevel = levels[i];
            var nextLevel = levels[i + 1];
            var diff = currentLevel - nextLevel;

            if (diff == 0)
            {
                isSafe = false;
                unsafeIndex = i+1;
                break;
            }

            if ((isDescending && (diff > 3 || currentLevel < nextLevel)) ||
                (!isDescending && (diff < -3 || currentLevel > nextLevel)))
            {
                isSafe = false;
                unsafeIndex = i + 1;
                break;
            }
        }

        return (isSafe, unsafeIndex) ;
    }
}
