using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaCaloriesV2
{
    class Pizza
    {
        private string name;
        public string Name {
            get => this.name;
            set 
            {
                if (value.Length<1 || value.Length>15 || value == string.Empty || value == "" || value == " ")
                {
                    Console.WriteLine("Pizza name should be between 1 and 15 symbols.");
                    Environment.Exit(0);
                }
                this.name = value;
            }
        }
        public int NumberOfToppings => Toppings.Count();
        public float totalCalories=>GetCalories();
        private List<Topping> Toppings;

        private Dough Dough { get; set; }

        public Pizza(string name, Dough dough) 
        {
            this.Name = name;
            this.Dough = dough;
            Toppings = new List<Topping>();
        }

        public void AddTopping(Topping topping) 
        {
            if (this.NumberOfToppings>=10)
            {
                Console.WriteLine($"Number of toppings should be in range [0..10].");
                Environment.Exit(0);
            }
            this.Toppings.Add(topping);
        }

        private float GetCalories() 
        {
            var sum = this.Dough.caloriesPerGram;
            foreach (var item in Toppings)
            {
                sum += item.CaloriesPerGram;
            }
            return sum;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.totalCalories:f2} Calories.";
        }
    }
}
