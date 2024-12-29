namespace Helpers;

public static class Day1
{
    public static int PuzzleA(string[] input)
    {
        var (leftList, rightList) = input
            .Select(line => line.Split("   "))
            .Aggregate(
                seed: (new List<int>(), new List<int>()),
                (agg, locationIds) =>
                {
                    agg.Item1.Add(int.Parse(locationIds[0]));
                    agg.Item2.Add(int.Parse(locationIds[1]));
                    return agg;
                });

        var orderedLeftList = leftList.Order().ToList();
        var orderedRightList = rightList.Order().ToList();

        return orderedLeftList.Zip(orderedRightList, (left, right) => Math.Abs(left - right)).Sum();
    }


   public static int PuzzleB(string[] input)
    {
        var (leftList, rightList) = input
            .Select(line => line.Split("   "))
            .Aggregate(
                seed: (new List<int>(), new List<int>()),
                (agg, locationIds) =>
                {
                    agg.Item1.Add(int.Parse(locationIds[0]));
                    agg.Item2.Add(int.Parse(locationIds[1]));
                    return agg;
                });

        var rightCounts = rightList.CountBy(number => number).ToDictionary();

        return leftList
            .Select(number => rightCounts.GetValueOrDefault(number, 0) * number).Sum();
    }
}
