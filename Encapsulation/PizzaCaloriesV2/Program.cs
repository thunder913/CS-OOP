using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PizzaCaloriesV2
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizzaDetails = Console.ReadLine().Split();
            var doughDetails = Console.ReadLine().Split();

            var pizzaName = MakeCamelCase(pizzaDetails[1]);
            var flourType = MakeCamelCase(doughDetails[1]);
            var technique = MakeCamelCase(doughDetails[2]);
            var doughWeight = float.Parse(doughDetails[3]);

            var dough = new Dough(flourType, technique, doughWeight);
            var pizza = new Pizza(pizzaName, dough);

            var input = Console.ReadLine().Split();

            while (input[0] != "END")
            {
                var type = MakeCamelCase(input[1]);
                var weight = float.Parse(input[2]);
                var topping = new Topping(type, weight, input[1]);
                pizza.AddTopping(topping);
                input = Console.ReadLine().Split();
            }

            Console.WriteLine(pizza.ToString());
        }

        public static string MakeCamelCase(string name) 
        {
            var sb = new StringBuilder();
            sb.Append(name[0].ToString().ToUpper());
            for (int i = 1; i < name.Length; i++)
            {
                sb.Append(name[i].ToString().ToLower());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
