using System;

namespace ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    Console.Write("Enter first name: ");
                    var firstName = Console.ReadLine();
                    Console.Write("Enter last name: ");
                    var lastName = Console.ReadLine();
                    Console.Write("Enter age: ");
                    var age = int.Parse(Console.ReadLine());
                    var person = new Person(firstName, lastName, age);
                    Console.WriteLine(person.ToString());
                }
                catch (ArgumentNullException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (ArgumentOutOfRangeException aore)
                {
                    Console.WriteLine(aore.Message);
                }
            }
        }
    }
}
