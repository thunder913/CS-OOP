using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Bird : Animal
    {
        public Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            this.Wingsize = wingSize;
        }

        double Wingsize { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Wingsize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
