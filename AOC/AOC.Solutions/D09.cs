using AOC.Utility;

namespace AOC;

public class D09 : DayBase
{
    protected override int Day => 9;

    private readonly Dictionary<(string placeA, string placeB), int> _flights;
    private readonly HashSet<string> _locations;
    private int min = int.MaxValue;
    private int max = int.MinValue;

    public D09()
    {
        _locations = new HashSet<string>();
        _flights = new Dictionary<(string placeA, string placeB), int>();

        foreach (var line in GetLines())
        {
            var args = line.Split(" ");
            _flights.Add((args[0], args[2]), Convert.ToInt32(args[4]));
            _flights.Add((args[2], args[0]), Convert.ToInt32(args[4]));
            _locations.Add(args[0]);
            _locations.Add(args[2]);
        }
    }

    public override int Puzzle_1()
    {
        min = int.MaxValue;

        foreach (var place in _locations)
        {
            var otherPlaces = _locations.Where(x => x != place).ToList();
            CalculateAllFlights(0, place, otherPlaces);
        }

        return min;
    }

    public override int Puzzle_2()
    {
        max = int.MinValue;

        foreach (var place in _locations)
        {
            var otherPlaces = _locations.Where(x => x != place).ToList();
            CalculateAllFlights(0, place, otherPlaces);
        }

        return max;
    }


    private void CalculateAllFlights(int length, string location, List<string> locations)
    {
        if (locations.Any() == false)
        {
            min = Math.Min(min, length);
            max = Math.Max(max, length);
        }

        foreach (var unvisited in locations)
        {
            var totalCost = length + _flights[(location, unvisited)];

            var newLocations = locations.Where(x => x != unvisited).ToList();

            CalculateAllFlights(totalCost, unvisited, newLocations);
        }
    }
}