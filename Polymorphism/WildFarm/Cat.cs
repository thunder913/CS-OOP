using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string region, string breed) : base(name, weight, region, breed)
        {
        }
        public double Multiplier = 0.30;
        public override string MakeSound()
        {
            return base.MakeSound() + "Meow";
        }
    }
}
