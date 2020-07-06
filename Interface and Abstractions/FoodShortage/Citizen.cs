using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    class Citizen : INameable, IAgeable
    {
        public int Food { get; set; } = 0;
        public string Name { get; set; }
        public int Age { get; set; }

        public string Id { get; set; }

        public DateTime Birthdate { get; set; }
        public Citizen(string name, int age, string id, DateTime birthdate) 
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
