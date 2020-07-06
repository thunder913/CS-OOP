using System;

namespace ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            while (input[0] != "End")
            {
                var name = input[0];
                var country = input[1];
                var age = int.Parse(input[2]);
                IPerson person = new Citizen(name, country, age);
                IResident resident = new Citizen(name, country, age);
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
                input = Console.ReadLine().Split();
            }

        }
    }
}
