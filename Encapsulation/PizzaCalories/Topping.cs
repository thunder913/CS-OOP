using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    class Topping
    {
        private string type;

        private double weight;
        private double defaultModifier = 2;
        private double toppingModifier = 1;

        private string Type {
            get 
            {
                return this.type;
            }
            set 
            {
                if (value!="Meat" && value!="Veggies" && value!="Cheese"&&value!="Sauce")
                {
                    Console.WriteLine($"Cannot place {value} on top of your pizza.");
                    Environment.Exit(0);
                }
                else 
                {
                    this.type = value;
                }
            }
        }

        private double Weight 
        {
            get => this.weight;
            set 
            {
                if (value<1 || value>50)
                {
                    Console.WriteLine($"{this.type} weight should be in the range [1..50].");
                    Environment.Exit(0);
                }
                else 
                {
                    this.weight = value;
                }
            }
        }

        public double CaloriesPerGram => weight * defaultModifier * toppingModifier;
        public Topping(string type, double weight) 
        {
            this.Type = type;
            this.Weight = weight;

            switch (type)
            {
                case "Meat": toppingModifier = 1.2;break;
                case "Veggies": toppingModifier = 0.8;break;
                case "Cheese": toppingModifier = 1.1;break;
                case "Sauce": toppingModifier = 0.9;break;
            }
        }   


    }
}
