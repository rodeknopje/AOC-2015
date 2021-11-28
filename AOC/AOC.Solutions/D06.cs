using System.Diagnostics;
using System.Text.RegularExpressions;
using AOC.Utility;

namespace AOC;

public class D06 : DayBase
{
    protected override int Day => 6;

    public override int Puzzle_1()
    {
        var regex = new Regex(@"(toggle|on|off)\s(\d.+?)\s.+?(\d.+)", RegexOptions.Compiled);
        var nodes = new int[1000, 1000];
        
        foreach (var line in GetLines())
        {
            var match = regex.Match(line);

            var state = match.Groups[1].ToString();
            var start = match.Groups[2].ToString().Split(",").Select(x => Convert.ToUInt32(x)).ToList();
            var end = match.Groups[3].ToString().Split(",").Select(x => Convert.ToUInt32(x)).ToList();

            Func<int, int> operation = state switch
            {
                "on" => x => 1,
                "off" => x => 0,
                "toggle" => x => Math.Abs(x - 1),
            };

            for (var y = start[1]; y <= end[1]; y++)
            for (var x = start[0]; x <= end[0]; x++)
            {
                nodes[y, x] = operation(nodes[y, x]);
            }
        }

        return nodes.Cast<int>().Sum();
    }

    public override int Puzzle_2()
    {
        var regex = new Regex(@"(toggle|on|off)\s(\d.+?)\s.+?(\d.+)", RegexOptions.Compiled);
        var nodes = new int[1000, 1000];
        
        foreach (var line in GetLines())
        {
            var match = regex.Match(line);

            var state = match.Groups[1].ToString();
            var start = match.Groups[2].ToString().Split(",").Select(x => Convert.ToUInt32(x)).ToList();
            var end = match.Groups[3].ToString().Split(",").Select(x => Convert.ToUInt32(x)).ToList();

            Func<int, int> operation = state switch
            {
                "on" => x => x + 1,
                "off" => x => x == 0 ? 0 : x - 1,
                "toggle" => x => x + 2,
            };

            for (var y = start[1]; y <= end[1]; y++)
            for (var x = start[0]; x <= end[0]; x++)
            {
                nodes[y, x] = operation(nodes[y, x]);
            }
        }

        return nodes.Cast<int>().Sum();
    }
}