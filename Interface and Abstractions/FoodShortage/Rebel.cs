using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel : IAgeable, INameable
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public int Food { get; set; } = 0;
        public string Group { get; set; }

        public Rebel(string name, int age, string group) 
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }
        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
