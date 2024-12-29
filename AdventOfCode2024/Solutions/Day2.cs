using System.Collections.Immutable;

namespace Helpers;

public static class Day2
{
    private enum Direction
    {
        Ascending,
        Descending
    }

    public static int PuzzleA(string[] input)
    {
        return input
            .Select(report => report
                .Split(" ")
                .Select(int.Parse)
                .ToImmutableList())
            .Select(IsSafe)
            .Count(isSafe => isSafe);
    }

    public static int PuzzleB(string[] input)
    {
        var reports = input.Select(report => report.Split(" ").Select(int.Parse).ToImmutableList());

        var safeCount = 0;
        foreach (var report in reports)
        {
            var isSafe = IsSafe(report);

            if (isSafe)
            {
                safeCount++;
            }
            else
            {
                for (var i = 0; i < report.Count; i++)
                {
                    var fixedReport = report.RemoveAt(i);
                    var fixedIsSafe = IsSafe(fixedReport);
                    if (fixedIsSafe)
                    {
                        safeCount++;
                        break;
                    }
                }
            }
        }

        return safeCount;
        ;
    }

    private static bool IsSafe(ImmutableList<int> report)
    {
        var isSafe = true;
        var direction = report.First() >= report.Last() ? Direction.Descending : Direction.Ascending;

        for (var i = 1; i < report.Count; i++)
        {
            var first = report[i - 1];
            var second = report[i];

            switch (direction)
            {
                case Direction.Ascending when second <= first:
                case Direction.Descending when second >= first:
                case Direction.Ascending or Direction.Descending when Math.Abs(first - second) > 3:
                    isSafe = false;
                    break;
            }

            if (!isSafe)
            {
                break;
            }
        }

        return isSafe;
    }
}
