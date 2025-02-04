using Streamove;
using System.Runtime.InteropServices;

Console.OutputEncoding = System.Text.Encoding.UTF8;

string command = Console.ReadLine();

List<Team> teams = new List<Team>();

List <IPlayer> players = new List<IPlayer>();

while (command != "exit")
{
    string[] commands = command.Split(" ");
    switch (commands[0])
    {
        case "create_team":
            Team team = new Team(commands[1]);
            teams.Add(team);
            break;
        case "create_player":
            IPlayer player = new Player(commands[1], commands[2]);
            players.Add(player);
            break;
        case "add_player":
            var teamToFind = teams.FirstOrDefault(x => x.Name == commands[1]);
            if (teamToFind is null)
            {
                Console.WriteLine("Несъществуващ отбор.");
                break;
            }
            var playerToFind = players.FirstOrDefault(x => x.Name == commands[2]);
            if (playerToFind is null)
            {
                Console.WriteLine("Несъществуващ играч.");
                break;
            }
            teamToFind.AddPlayer(playerToFind);
            break;
        case "remove_player":
            var teamToFindToRemove = teams.FirstOrDefault(x => x.Name == commands[1]);
            if (teamToFindToRemove is null)
            {
                Console.WriteLine("Несъществуващ отбор.");
                break;
            }
            teamToFindToRemove.RemovePlayer(commands[2]);
            break;
        case "print_team":
            var teamToFindLog = teams.FirstOrDefault(x => x.Name == commands[1]);
            if (teamToFindLog is null)
            {
                Console.WriteLine("Несъществуващ отбор.");
                break;
            }
            try
            {
                teamToFindLog.Log(commands[2]);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            break;
        case "print_log_txt":
            var teamToLog = teams.FirstOrDefault(x => x.Name == commands[1]);
            if (teamToLog is null)
            {
                Console.WriteLine("Несъществуващ отбор.");
                break;
            }
            teamToLog.PrintLog();
            break;
        case "print_log_excel":
            break;
    }
    command = Console.ReadLine();
}
