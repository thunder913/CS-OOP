using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mammal : Animal
    {
        public string LivingRegion { get; set; }
        public Mammal(string name, double weight, string region) : base(name, weight)
        {
            this.LivingRegion = region;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
