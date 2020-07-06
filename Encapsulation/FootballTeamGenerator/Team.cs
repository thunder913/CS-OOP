using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FootballTeamGenerator
{
    class Team
    {
        public string name;

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
        public float Rating 
        { get 
            {
                float sum = 0F;
                foreach (var item in players)
                {
                    sum += item.AverageStat;
                }
                if (players.Count()==0)
                {
                    return sum;
                }
                return sum/players.Count();
            }
        }
        private List<Player> players = new List<Player>();

        public Team(string name) 
        {
            this.Name = name;
        }

        public void AddPlayer(Player player) 
        {
            players.Add(player);
        }

        public void Remove(string playerName) 
        {
            var player = players.FirstOrDefault(x => x.Name == playerName);
            if (player== null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }
            players.Remove(player);
        }
        public string GetRating() 
        {
            return $"{this.Name} - {Math.Round(this.Rating,0)}";
        }
    }
}
