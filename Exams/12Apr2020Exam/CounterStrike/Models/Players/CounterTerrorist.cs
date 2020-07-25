using CounterStrike.Models.Guns.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public class CounterTerrorist : Player
    {
        public CounterTerrorist(string name, int health, int armor, IGun gun) : base(name, health, armor, gun)
        {
        }
    }
}
