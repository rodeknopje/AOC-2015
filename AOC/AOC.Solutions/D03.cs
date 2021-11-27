using AOC.Utility;

namespace AOC;

public class D03 : DayBase
{
    protected override int Day => 3;

    public override int Puzzle_1()
    {
        var text = GetText();
        var visited = new HashSet<(int x, int y)>();

        var x = 0;
        var y = 0;

        visited.Add((x, y));

        foreach (var c in text)
        {
            x += c == '<' ? -1 : c == '>' ? +1 : 0;
            y += c == 'v' ? -1 : c == '^' ? +1 : 0;

            visited.Add((x, y));
        }

        return visited.Count;
    }

    public override int Puzzle_2()
    {
        var text = GetText();
        var visited = new HashSet<(int, int)>();

        (int x, int y) santaPosition = (0, 0);
        (int x, int y) robotPosition = (0, 0);

        visited.Add(santaPosition);

        for (var i = 0; i < text.Length; i++)
        {
            var c = text[i];

            if (i % 2 == 0)
            {
                santaPosition.x += c == '<' ? -1 : c == '>' ? +1 : 0;
                santaPosition.y += c == 'v' ? -1 : c == '^' ? +1 : 0;
                
                visited.Add(santaPosition);
            }
            else
            {
                robotPosition.x += c == '<' ? -1 : c == '>' ? +1 : 0;
                robotPosition.y += c == 'v' ? -1 : c == '^' ? +1 : 0;
                
                visited.Add(robotPosition);
            }
        }

        return visited.Count;
    }
}