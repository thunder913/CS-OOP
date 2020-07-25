using CounterStrike.Models.Guns.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public class Terrorist : Player
    {
        public Terrorist(string name, int health, int armor, IGun gun) : base(name, health, armor, gun)
        {
        }
    }
}
