using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizzaInput = Console.ReadLine().Split();
            var doughtInput = Console.ReadLine().Split();

            var technique = MakeCamelCase(doughtInput[2]);
            var flourType = MakeCamelCase(doughtInput[1]);
            var dough = new Dough(technique, flourType, double.Parse(doughtInput[3]));
            var pizza = new Pizza(pizzaInput[1], dough);

            var input = Console.ReadLine().Split();
            while (input[0]!="END")
            {
                var toppingName = MakeCamelCase(input[1]);
                var toppingWeight = double.Parse(input[2]);
                var topping = new Topping(toppingName, toppingWeight);
                pizza.AddTopping(topping);
                input = Console.ReadLine().Split();
            }

            Console.WriteLine($"{pizza.ToString()}");
        }
        public static string MakeCamelCase(string input)
        {
            var sb = new StringBuilder();
            sb.Append(input[0].ToString().ToUpper());
            for (int i = 1; i < input.Length; i++)
            {
                sb.Append(input[i].ToString().ToLower());
            }
            return sb.ToString().TrimEnd();
        }
    }

    
}
