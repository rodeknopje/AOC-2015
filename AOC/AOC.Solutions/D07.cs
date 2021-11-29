using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using AOC.Utility;

namespace AOC;

public class D07 : DayBase
{
    protected override int Day => 7;

    private readonly Regex _startWireRegex;
    private readonly Regex _operationRegex;

    private readonly Dictionary<string, ushort> _cached;
    private List<string> _lines;

    public D07()
    {
        _startWireRegex = new Regex(@"^([a-z\d]+)\s->\s([a-z]+)$", RegexOptions.Compiled);
        _operationRegex = new Regex(@"^((?:[a-z\d]+|))\s?([A-Z]+)\s([a-z\d]+)\s->\s([a-z]+)");

        _cached = new Dictionary<string, ushort>();

        _lines = GetLines();
    }

    public override int Puzzle_1()
    {
        return GetValue();
    }

    private ushort GetValue()
    {
        _cached.Clear();
        return GetValueRecursive("a");
    }

    private ushort GetValueRecursive(string wireId)
    {
        if (_cached.TryGetValue(wireId, out var cached))
        {
            return cached;
        }

        var wire = _lines.First(line => line.EndsWith($"-> {wireId}"));

        var startWireResult = _startWireRegex.Match(wire);

        if (startWireResult.Success)
        {
            var lSide = startWireResult.Groups[1].ToString();

            if (new Regex("[a-z]").IsMatch(lSide))
            {
                return GetValueRecursive(lSide);
            }

            var result = Convert.ToUInt16(startWireResult.Groups[1].ToString());

            _cached.Add(wireId, result);

            return result;
        }

        var operationValues = _operationRegex.Match(wire);

        var l = operationValues.Groups[1].ToString();
        var r = operationValues.Groups[3].ToString();

        var bitwise = operationValues.Groups[2].ToString();

        var lValue = new Regex("[a-z]").IsMatch(l) ? GetValueRecursive(l) :
            string.IsNullOrEmpty(l) ? (ushort) 0 : Convert.ToUInt16(l);
        var rValue = new Regex("[a-z]").IsMatch(r) ? GetValueRecursive(r) :
            string.IsNullOrEmpty(r) ? (ushort) 0 : Convert.ToUInt16(r);

        var value = bitwise switch
        {
            "OR" => lValue | rValue,
            "AND" => lValue & rValue,
            "XOR" => lValue ^ rValue,
            "LSHIFT" => lValue << rValue,
            "RSHIFT" => lValue >> rValue,
            "NOT" => ~rValue,
        };

        _cached.Add(wireId, (ushort) value);

        return (ushort) value;
    }

    public override int Puzzle_2()
    {
        _lines = _lines.Select(line => line.EndsWith("-> b") ? $"{GetValue()} -> b" : line).ToList();
        return GetValue();
    }
}