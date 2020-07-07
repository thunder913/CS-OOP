using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    class Mouse : Mammal
    {
        public Mouse(string name, double weight, string region) : base(name, weight, region)
        {
        }

        public double Multiplier = 0.10;
        public override string MakeSound()
        {
            return base.MakeSound() + "Squeak";
        }
    }
}
