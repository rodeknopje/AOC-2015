using AOC.Utility;

namespace AOC;

public class D02 : DayBase
{
    protected override int Day => 2;

    public override int Puzzle_1()
    {
        var lines = GetLines();

        var sum = 0;

        foreach (var line in lines)
        {
            var numbers = line
                .Split('x')
                .Select(x => Convert.ToInt32(x))
                .ToList();

            var l = numbers[0];
            var w = numbers[1];
            var h = numbers[2];

            var areas = new[]
            {
                2 * l * w,
                2 * w * h,
                2 * h * l,
            };

            sum += areas.Sum();
            sum += areas.Min() / 2;
        }

        return sum;
    }

    public override int Puzzle_2()
    {
        var lines = GetLines();

        var sum = 0;

        foreach (var line in lines)
        {
            var numbers = line
                .Split('x')
                .Select(x => Convert.ToInt32(x))
                .OrderBy(x => x)
                .ToList();

            sum += 2 * numbers.Take(2).Sum();
            sum += numbers.Aggregate((a, b) => a * b);
        }

        return sum;
    }
}