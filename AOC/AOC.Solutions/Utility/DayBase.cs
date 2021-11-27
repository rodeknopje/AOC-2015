namespace AOC.Utility;

public abstract class DayBase
{
    protected abstract int Day { get; }
    public abstract int Puzzle_1();
    public abstract int Puzzle_2();
    
    protected List<string> GetLines() => File.ReadAllLines($"../../../inputs/{Day}.txt").ToList();
    protected string GetText() => File.ReadAllText($"../../../inputs/{Day}.txt");
}