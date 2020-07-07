using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; } = 0;

        public Animal() { }
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public virtual string MakeSound()
        {
            //return $"{this.GetType().Name} - ";
            return "";
        }

        public virtual void EatFood(int foodeaten, double multiplier) 
        {
            this.FoodEaten += foodeaten;
            this.Weight += foodeaten * multiplier;
        }

        public string AnimalDoesntEat(string foodType) 
        {
            return $"{this.GetType().Name} does not eat {foodType}!";
        }
    }
}
