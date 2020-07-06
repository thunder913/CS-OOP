using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    class BladeKnight:DarkKnight
    {
        public BladeKnight(string name, int level) : base(name, level) { }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
