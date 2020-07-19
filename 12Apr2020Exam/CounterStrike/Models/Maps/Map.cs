using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public Map() { }
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = new List<Terrorist>();
            var counterTerrorists = new List<CounterTerrorist>();
            foreach (var player in players)
            {
                if (player.GetType().Name == "Terrorist")
                {
                    terrorists.Add((Terrorist)player);
                }
                else 
                {
                    counterTerrorists.Add((CounterTerrorist)player);
                }
            }

            while (terrorists.Any(x => x.IsAlive == true) && counterTerrorists.Any(x => x.IsAlive == true))
            {
                for (int i = 0; i < terrorists.Count(); i++)
                {
                    var currentTerrorist = terrorists[i];
                    if (currentTerrorist.IsAlive)
                    {
                        int counterTerroristCount = counterTerrorists.Count();
                        for (int c = 0; c < counterTerroristCount; c++)
                        {
                            int bullets = currentTerrorist.Gun.Fire();
                            counterTerrorists[c].TakeDamage(bullets);
                        }
                    }
                }

                for (int i = 0; i < counterTerrorists.Count(); i++)
                {
                    var currentCounterTerrorist = counterTerrorists[i];
                    if (currentCounterTerrorist.IsAlive)
                    {
                        int terroristCount = terrorists.Count();
                        for (int c = 0; c < terroristCount; c++)
                        {
                            int bullets = currentCounterTerrorist.Gun.Fire();
                            terrorists[c].TakeDamage(bullets);
                        }
                    }
                }
            }

            if (terrorists.Any(x=>x.IsAlive))
            {
                return "Terrorist wins!";
            }
            else 
            {
                return "Counter Terrorist wins!";
            }
        }
    }
}
