using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace FootballTeamGeneratorV2
{
    class Team
    {
        private string name;
        public string Name { get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }
        public int Rating => CalculateStats();

        List<Player> players = new List<Player>();

        public Team(string name) 
        {
            this.Name = name;
        }

        public void AddPlayer(Player player) 
        {
            players.Add(player);
        }

        public void RemovePlayer(string name) 
        {
            var player = players.FirstOrDefault(x => x.Name == name);
            if (player==null)
            {
                throw new ArgumentException($"Player {name} is not in {this.Name} team.");
            }
            players.Remove(player);
        }
        private int CalculateStats() 
        {
            var sum = 0;
            foreach (var player in players)
            {
                sum += player.AverageStats;
            }

            if (players.Count()==0)
            {
                return sum;
            }
            return sum / players.Count();
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
