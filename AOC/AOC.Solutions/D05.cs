using AOC.Utility;
using System.Text.RegularExpressions;

namespace AOC;

public class D05 : DayBase
{
    protected override int Day => 5;

    public override int Puzzle_1()
    {
        var sum = 0;

        foreach (var line in GetLines())
        {
            var i = 0;

            if (line.Count(x => "aeiou".Contains(x)) >= 3 &&
                line.Skip(1).Any(a => a == line[++i - 1]) &&
                !new Regex("ab|cd|pq|xy").IsMatch(line))
            {
                sum++;
            }
        }

        return sum;
    }

    public override int Puzzle_2()
    {
        var sum = 0;

        foreach (var line in GetLines())
        {
            var i = 1;

            if (CheckForRepeatingPair(line) && line.Skip(2).Any(a => a == line[++i - 2]))
            {
                sum++;
            }
        }

        return sum;
    }

    private bool CheckForRepeatingPair(string line)
    {
        while (string.IsNullOrEmpty(line) == false)
        {
            var pair = string.Concat(line.Take(2));

            if (string.Concat(line.Skip(2)).Contains(pair))
            {
                return true;
            }

            line = string.Concat(line.Skip(1));
        }

        return false;
    }
}