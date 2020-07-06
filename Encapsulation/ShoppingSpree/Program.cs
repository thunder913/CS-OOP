using System;
using System.Linq;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPeople = Console.ReadLine().Split(new char[] { ';'},StringSplitOptions.RemoveEmptyEntries).ToList();
            var listPeople = new List<Person>();
            foreach (var item in inputPeople)
            {
                var currentPerson = item.Split(new char[] { '='}, StringSplitOptions.RemoveEmptyEntries).ToList();
                var person = new Person(currentPerson[0], decimal.Parse(currentPerson[1]));
                listPeople.Add(person);
            }

            var listProducts = new List<Product>();
            var inputProducts = Console.ReadLine().Split(new char[] { ';'},StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var item in inputProducts)
            {
                var currentProduct = item.Split(new char[] { '='},StringSplitOptions.RemoveEmptyEntries).ToList();
                var product = new Product(currentProduct[0], decimal.Parse(currentProduct[1]));
                listProducts.Add(product);
            }

            var command = Console.ReadLine().Split();
            while (command[0] != "END")
            {
                Console.WriteLine(listPeople.FirstOrDefault(x => x.name == command[0])
                    .AddProduct(listProducts.FirstOrDefault(x => x.Name == command[1])));
                command = Console.ReadLine().Split();
            }

            foreach (var item in listPeople)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
