using System;
using System.Linq;
using System.Collections.Generic;
namespace FootballTeamGeneratorV2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            var command = Console.ReadLine().Split(";");
            while (command[0]!="END")
            {
                try
                {
                    if (command[0] == "Team")
                    {
                        var teamName = command[1];
                        teams.Add(new Team(teamName));
                    }
                    else if (command[0] == "Add")
                    {
                        var teamName = command[1];
                        var playerName = command[2];
                        var endurance = int.Parse(command[3]);
                        var sprint = int.Parse(command[4]);
                        var dribble = int.Parse(command[5]);
                        var passing = int.Parse(command[6]);
                        var shooting = int.Parse(command[7]);
                        var team = teams.FirstOrDefault(x => x.Name == teamName);
                        if (team == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                        var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        team.AddPlayer(player);
                    }
                    else if (command[0] == "Remove")
                    {
                        var teamName = command[1];
                        var playerName = command[2];
                        var team = teams.FirstOrDefault(x => x.Name == teamName);
                        if (team!= null)
                        {
                            team.RemovePlayer(playerName);
                        }
                        else 
                        {
                            throw new Exception($"Team {teamName} does not exist.");
                        }
                    }
                    else if (command[0] == "Rating")
                    {
                        var teamName = command[1];
                        var team = teams.FirstOrDefault(x => x.Name == teamName);
                        if (team== null)
                        {
                            throw new Exception($"Team {teamName} does not exist.");
                        }
                        Console.WriteLine(team.ToString());
                    }
                }catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
                command = Console.ReadLine().Split(";");
            }
        }
    }
}
