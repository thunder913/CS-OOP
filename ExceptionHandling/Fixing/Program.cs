using System;

namespace Fixing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weekdays = new string[]
            {
                "Sunday",
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday"
            };
            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(weekdays[i].ToString());
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("There are only 5 days in the week!");
            }
            
            Console.ReadLine();
        }
    }
}
