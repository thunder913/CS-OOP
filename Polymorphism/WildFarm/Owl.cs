using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    class Owl : Bird
    {
        public double Multiplier = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string MakeSound()
        {
            return base.MakeSound() + "Hoot Hoot";
        }
    }
}
