using System.Security.Cryptography;
using System.Text;
using AOC.Utility;

namespace AOC;

public class D04 : DayBase
{
    protected override int Day => 4;

    public override int Puzzle_1() => GetLowestSuffix("00000");

    public override int Puzzle_2() => GetLowestSuffix("000000");
    
    private int GetLowestSuffix(string prefix)
    {
        using var md5 = MD5.Create();

        for (var i = 0;; i++)
        {
            var inputBytes = Encoding.ASCII.GetBytes(GetText() + i);

            var hashBytes = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();

            foreach (var b in hashBytes)
            {
                sb.Append(b.ToString("X2"));
            }

            if (sb.ToString().StartsWith(prefix))
            {
                return i;
            }
        }
    }
}