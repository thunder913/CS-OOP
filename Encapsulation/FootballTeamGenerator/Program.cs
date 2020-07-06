using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = new List<Team>();

            var input = Console.ReadLine().Split(";");
            while (input[0] != "END")
            {
                try
                {
                    if (input[0] == "Team")
                    {
                        var team = new Team(input[1]);
                            teams.Add(team);
                    }
                    else if (input[0] == "Add")
                    {
                        var teamName = input[1];
                        var team = teams.FirstOrDefault(x => x.Name == teamName);
                        var playerName = input[2];
                        var endurance = int.Parse(input[3]);
                        var sprint = int.Parse(input[4]);
                        var dribble = int.Parse(input[5]);
                        var passing = int.Parse(input[6]);
                        var shooting = int.Parse(input[7]);
                        var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        if (team == null)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            team.AddPlayer(player);
                        }
                    }
                    else if (input[0] == "Remove")
                    {
                        var teamName = input[1];
                        var currentTeam = teams.FirstOrDefault(x => x.Name == teamName);
                        if (currentTeam == null)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            var playerName = input[2];
                            currentTeam.Remove(playerName);
                        }
                    }
                    else if (input[0] == "Rating")
                    {
                        var teamName = input[1];
                        var currentTeam = teams.FirstOrDefault(x => x.Name == teamName);
                        if (currentTeam == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            Console.WriteLine(currentTeam.GetRating());
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                input = Console.ReadLine().Split(";");
            }

        }
    }
}
