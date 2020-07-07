using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            var listAnimals = new List<Animal>();
            var animalInput = Console.ReadLine().Split();
            while (animalInput[0] != "End")
            {
                var type = animalInput[0];
                var name = animalInput[1];
                var weight = double.Parse(animalInput[2]);
                var food = Console.ReadLine().Split();
                var foodType = food[0];
                var foodCount = int.Parse(food[1]);
                if (animalInput.Count() == 4)
                {
                    if (double.TryParse(animalInput[3], out double wingSize))
                    {
                        if (type == "Hen")
                        {
                            var hen = new Hen(name, weight, wingSize);
                            Console.WriteLine(hen.MakeSound());
                            hen.EatFood(foodCount, hen.Multiplier);
                            listAnimals.Add(hen);
                        
                        }
                        else
                        {
                            var owl = new Owl(name, weight, wingSize);
                                Console.WriteLine(owl.MakeSound());
                            if (foodType == "Meat")
                            {
                                owl.EatFood(foodCount, owl.Multiplier);
                            }
                            else 
                            {
                                Console.WriteLine(owl.AnimalDoesntEat(foodType));
                            }
                            listAnimals.Add(owl);
                        }
                    }
                    else
                    {
                        var region = animalInput[3];
                        if (type == "Dog")
                        {
                            var dog = new Dog(name, weight, region);
                                Console.WriteLine(dog.MakeSound());
                            if (foodType == "Meat")
                            {
                                dog.EatFood(foodCount, dog.Multiplier);
                            }
                            else 
                            {
                                Console.WriteLine(dog.AnimalDoesntEat(foodType));
                            }
                            listAnimals.Add(dog);
                        }
                        else
                        {
                            var mouse = new Mouse(name, weight, region);
                                Console.WriteLine(mouse.MakeSound());
                            if (foodType == "Vegetable" || foodType == "Fruit")
                            {
                                mouse.EatFood(foodCount, mouse.Multiplier);
                            }
                            else 
                            {
                                Console.WriteLine(mouse.AnimalDoesntEat(foodType));
                            }
                            listAnimals.Add(mouse);
                        }
                    }  
                }else 
                {
                    var region = animalInput[3];
                    var breed = animalInput[4];
                    if (type == "Cat")
                    {
                        var cat = new Cat(name, weight, region, breed);
                            Console.WriteLine(cat.MakeSound());
                        if (foodType == "Meat" || foodType == "Vegetable")
                        {
                            cat.EatFood(foodCount, cat.Multiplier);
                        }
                        else 
                        {
                            Console.WriteLine(cat.AnimalDoesntEat(foodType));
                        }
                        listAnimals.Add(cat);
                    }
                    else 
                    {
                        var tiger = new Tiger(name, weight, region, breed);
                        Console.WriteLine(tiger.MakeSound());
                        if (foodType == "Meat")
                        {
                            tiger.EatFood(foodCount, tiger.Multiplier);
                        }
                        else 
                        {
                            Console.WriteLine(tiger.AnimalDoesntEat(foodType));
                        }
                        listAnimals.Add(tiger);
                    }
                }
                animalInput = Console.ReadLine().Split();
            }

            foreach (var item in listAnimals)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
