using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCaloriesV2
{
    class Topping
    {
        private string type;
        private float weight;
        private float modifier;
        private string originalNameInput;
        public float CaloriesPerGram => weight * modifier * 2;

        private string Type
        {
            get => this.type;
            set
            {
                if (value == "Meat")
                {
                    modifier = 1.2F;
                }
                else if (value == "Veggies")
                {
                    modifier = 0.8F;
                }
                else if (value == "Cheese")
                {
                    modifier = 1.1F;
                }
                else if (value == "Sauce")
                {
                    modifier = 0.9F;
                }
                else
                {
                    Console.WriteLine($"Cannot place {this.originalNameInput} on top of your pizza.");
                    Environment.Exit(0);
                }
                this.type = value;

            }
        }

        private float Weight
        {
            get => this.weight;
            set
            {
                if (value<1 || value>50)
                {
                    Console.WriteLine($"{this.Type} weight should be in the range [1..50].");
                    Environment.Exit(0);
                }
                else 
                {
                    this.weight = value;
                }
            }
        }

        public Topping(string name, float weight, string originalName) 
        {
            this.originalNameInput = originalName;
            this.Type = name;
            this.Weight = weight;
        }
    }
}
