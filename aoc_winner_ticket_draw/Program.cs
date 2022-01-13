// See https://aka.ms/new-console-template for more information

using System.Text.Json.Serialization;

var players = new Dictionary<string, int>()
{
    {"Name1", 30 },
    {"Name2",5},
    {"Name3", 5},
    {"Name4",10}
};

var pool = new Pool();

foreach (var player in players)
{
    for (int i = 0; i < player.Value; i++)
    {
        pool.AddTicket(player.Key);
    }
}

var winner = pool.GetWinnerAndRemoveFromPool();
Console.WriteLine("First place: " + winner);

var secondPlaceWinner = pool.GetWinnerAndRemoveFromPool();
Console.WriteLine("Second place: " + secondPlaceWinner);

var thirdPlaceWinner = pool.GetWinnerAndRemoveFromPool();
Console.WriteLine("Third place: " + thirdPlaceWinner);

class Pool
{
    private readonly Random _random = new Random();
    private readonly List<string> _tickets = new List<string>();

    public string GetWinnerAndRemoveFromPool()
    {
        var winningTicket = _random.Next(_tickets.Count - 1);
        var winner = _tickets[winningTicket];

        // Remove winner.
        _tickets.RemoveAll(x => x == winner);
        return winner;
    }

    public void AddTicket(string ticketName)
    {
        _tickets.Add(ticketName);
    }
}