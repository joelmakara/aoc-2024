
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

            if (IsReportSafe(levels))
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
        var isSafe = true;
        var unsafeLevelCount = 0;
        var isDescending = IsDescending(levels);

        for (int i = 0; i < levels.Count - 1; i++)
        {
            var currentLevel = levels[i];
            var nextLevel = levels[i + 1];
            var diff = currentLevel - nextLevel;

            if (diff == 0)
            {
                if (unsafeLevelCount == 0)
                {
                    i++;
                    unsafeLevelCount++;
                }
                else
                {
                    isSafe = false;
                    break;
                }
            }

            if ((isDescending && (diff > 3 || currentLevel < nextLevel)) ||
                (!isDescending && (diff < -3 || currentLevel > nextLevel)))
            {
                if (unsafeLevelCount == 0)
                {
                    i++;
                    unsafeLevelCount++;
                }
                else
                {
                    isSafe = false;
                    break;
                }
            }
        }

        return isSafe;
    }

    private bool IsDescending(List<int> numbers)
    {
        var result = new List<bool>();

        for (int i = 0; i < numbers.Count - 1; i++)
        {
            result.Add(numbers[i] > numbers[i + 1]);
        }

        return result.Count(x => x == true) > result.Count(x => x == false);
    }

    private bool IsMostlyDescending(List<int> numbers)
    {
        return numbers.Zip(numbers.Skip(1), (current, next) => current > next)
                      .Count(isDescending => isDescending) > numbers.Count / 2;
    }


    private bool IsReportSafe(List<int> levels)
    {
        var isSafe = true;
        var unsafeLevelCount = 0;
        var isDescending = levels[0] > levels[1];

        for (int i = 0; i < levels.Count - 1; i++)
        {
            var currentLevel = levels[i];
            var nextLevel = levels[i + 1];
            var diff = currentLevel - nextLevel;

            if (diff == 0)
            {
                isSafe = false;
                break;
            }

            if ((isDescending && (diff > 3 || currentLevel < nextLevel)) ||
                (!isDescending && (diff < -3 || currentLevel > nextLevel)))
            {
                isSafe = false;
                break;
            }
        }

        return isSafe;
    }
}
