using System.Net;

namespace AOC.Utility;

public abstract class DayBase
{
    protected abstract int Day { get; }
    
    private const int Year = 2015;
    
    public abstract int Puzzle_1();
    public abstract int Puzzle_2();

    private string InputFile => $"../../../inputs/{Day}.txt";
    private string SessionFile => "../../../../session.txt";

    protected List<string> GetLines()
    {
        if (File.Exists(InputFile) == false)
        {
            FetchInput();
        }

        return File.ReadAllLines($"../../../inputs/{Day}.txt").ToList();
    }

    protected string GetText()
    {
        if (File.Exists(InputFile) == false)
        {
            FetchInput();
        }

        return File.ReadAllText($"../../../inputs/{Day}.txt");
    }

    private void FetchInput()
    {
        var cookieContainer = new CookieContainer();
        var session = File.ReadAllText(SessionFile);

        cookieContainer.Add(
            new Uri("https://adventofcode.com/"),
            new Cookie("session", session));

        var clientHandler = new HttpClientHandler
        {
            CookieContainer = cookieContainer,
            UseCookies = true
        };

        var client = new HttpClient(clientHandler);

        var input = client.GetStringAsync($"https://adventofcode.com/{Year}/day/{Day}/input").Result;

        File.WriteAllText(InputFile, input.Trim());
    }
}