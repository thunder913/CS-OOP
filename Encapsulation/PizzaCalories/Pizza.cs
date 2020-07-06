using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaCalories
{
    class Pizza
    {
        public string name;
        public string Name 
        {
            get => this.name;
            set 
            {
                if (value == "" || value == string.Empty || value == " " || value.Length<1||value.Length>15)
                {
                    Console.WriteLine("Pizza name should be between 1 and 15 symbols.");
                    Environment.Exit(0);
                }

                this.name = value;
            }
        }
        public List<Topping> toppings;

        public double totalCalories => CalculateCalories();
        public int toppingsCount => toppings.Count();
        private Dough dough;
        
        public Pizza(string name, Dough dough) 
        {
            this.Name = name;
            this.dough = dough;
            toppings = new List<Topping>();
        }

        public double CalculateCalories() 
        {
            double sum = 0;
            sum += this.dough.CaloriesPerGram;
            foreach (var item in toppings)
            {
                sum += item.CaloriesPerGram;
            }
            return sum;
        }

        public void AddTopping(Topping topping) 
        {
            if (this.toppings.Count()>10)
            {
                Console.WriteLine($"Number of toppings should be in range [0..10].");
                Environment.Exit(0);
            }
            this.toppings.Add(topping);
        }
        public override string ToString()
        {
            return $"{this.name} - {this.totalCalories:f2} Calories.";
        }
    }
}
