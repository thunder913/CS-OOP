namespace Animals
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var animals = new List<Animal>();
            var input = Console.ReadLine().Split();

            while (input[0] != "Beast!")
            {
                var type = input[0];
                if (type != "Kitten" && type != "Tomcat" && type != "Dog" && type != "Cat" && type != "Frog")
                {
                    Console.WriteLine("Invalid input!");
                    goto End;
                }

                var animalInfo = Console.ReadLine().Split();
                var name = animalInfo[0];
                var age = int.Parse(animalInfo[1]);
                if (age < 0)
                {
                    Console.WriteLine("Invalid input!");
                    goto End;
                }
                else if (type == "Kitten")
                {
                    animals.Add(new Kitten(name, age));
                    goto End;
                }
                else if (type == "Tomcat")
                {
                    animals.Add(new Tomcat(name, age));
                    goto End;
                }

                var gender = animalInfo[2];
                if (gender != "Male" && gender != "Female")
                {
                    Console.WriteLine("Invalid input!");
                }
                else if (type == "Cat")
                {
                    animals.Add(new Cat(name, age, gender));
                }
                else if (type == "Dog")
                {
                    animals.Add(new Dog(name, age, gender));
                }
                else if (type == "Frog")
                {
                    animals.Add(new Frog(name, age, gender));
                }
                goto End;
            End:;
                input = Console.ReadLine().Split();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}

