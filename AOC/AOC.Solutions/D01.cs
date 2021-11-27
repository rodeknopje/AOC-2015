using System.Linq;
using AOC.Utility;

namespace AOC;

public class D01 : DayBase
{
    protected override int Day => 1;
    
    public override int Puzzle_1()
    {
        var input = GetText();

        var ups   = input.Count(x => x == '(');
        var downs = input.Count(x => x == ')');

        return ups - downs;
    }

    public override int Puzzle_2()
    {
        var input = GetText();
        
        int floor = 0, i = 0;

        for (; floor >= 0; i++)
        {
            floor += input[i] == '(' ? +1 : -1;

            if (floor == -1)
            {
                return ++i;
            }
        }

        return -1;
    }
}