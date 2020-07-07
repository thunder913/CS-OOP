using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    class Dog : Mammal
    {
        public Dog(string name, double weight, string region) : base(name, weight, region)
        {
        }
        public double Multiplier = 0.40;
        public override string MakeSound()
        {
            return base.MakeSound() + "Woof!";
        }
    }
}
