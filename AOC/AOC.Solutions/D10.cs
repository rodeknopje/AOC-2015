using System.Text;
using AOC.Utility;

namespace AOC;

public class D10 : DayBase
{
    protected override int Day => 10;

    public override int Puzzle_1() => GetLookAndSay(GetText(), 40).Length;

    public override int Puzzle_2() => GetLookAndSay(GetText(), 50).Length;
    
    private string GetLookAndSay(string original, int times)
    {
        for (var i = 0; i < times; i++)
        {
            var sb = new StringBuilder();

            for (var j = 0; j < original.Length;)
            {
                var number = original[j];

                if (j < original.Length - 2 && original[j] == original[j + 1] && original[j] == original[j + 2])
                {
                    sb.Append(3);
                    sb.Append(number);
                    j += 3;
                }
                else if (j < original.Length - 1 && original[j] == original[j + 1])
                {
                    sb.Append(2);
                    sb.Append(number);
                    j += 2;
                }
                else
                {
                    sb.Append(1);
                    sb.Append(number);
                    j += 1;
                }
            }

            original = sb.ToString();
        }

        return original;
    }
}