using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            var list = new List<IBirthdate>();
            var input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                var name = input[1];

                if (input[0] == "Citizen")
                {
                    var age = int.Parse(input[2]);
                    var id = input[3];
                    DateTime birthdate = DateTime.ParseExact(input[4], "dd/mm/yyyy", CultureInfo.InvariantCulture);
                    list.Add(new Citizen(name, age, id, birthdate));
                }
                else if (input[0] == "Pet")
                {
                    DateTime birthdate = DateTime.ParseExact(input[2], "dd/mm/yyyy", CultureInfo.InvariantCulture);
                    list.Add(new Pet(name, birthdate));
                }
                input = Console.ReadLine().Split();
            }

            var year = Console.ReadLine();
            foreach (var item in list)
            {
                if (item.Birthdate.Year == int.Parse(year))
                {
                    Console.WriteLine(item.Birthdate.ToString("dd/mm/yyyy", CultureInfo.InvariantCulture));
                }
            }
        }   
    }
}
