using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string region, string breed) : base(name, weight, region, breed)
        {
        }
        public double Multiplier = 1;
        public override string MakeSound()
        {
            return base.MakeSound()+ "ROAR!!!";
        }
    }
}
