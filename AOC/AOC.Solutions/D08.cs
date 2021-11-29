using System.Text;
using System.Text.RegularExpressions;
using AOC.Utility;

namespace AOC;

public class D08 : DayBase
{
    protected override int Day => 8;

    public override int Puzzle_1()
    {
        return GetText().Split('\n').Sum(line => line.Length - Regex.Unescape(line).Skip(1).SkipLast(1).Count());
    }

    public override int Puzzle_2()
    {
        return GetText().Split('\n').Sum(line => line.Count(x => x == '\\') + line.Count(x => x == '\"') + 2);
    }
}