using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = int.Parse(Console.ReadLine());
            List<INameable> list = new List<INameable>();
            for (int i = 0; i < inputs; i++)
            {
                var current = Console.ReadLine().Split();
                if (current.Count() == 3)
                {
                    list.Add(new Rebel(current[0], int.Parse(current[1]), current[2]));
                }
                else 
                {
                    var name = current[0];
                    var age = int.Parse(current[1]);
                    var id = current[2];
                    var datetime = DateTime.ParseExact(current[3], "dd/mm/yyyy", CultureInfo.InvariantCulture);
                    list.Add(new Citizen(name, age, id, datetime));
                }
            }

            var input = Console.ReadLine();
            while (input!= "End")
            {
                var person = list.FirstOrDefault(x => x.Name == input);
                if (person!= null)
                {
                    person.BuyFood();
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(list.Sum(x=>x.Food));
        }
    }
}
