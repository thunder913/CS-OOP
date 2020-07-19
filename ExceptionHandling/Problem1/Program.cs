using System;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number:");
            var number = float.Parse(Console.ReadLine());

            try
            {
                if (number<0)
                {
                    throw new ArgumentOutOfRangeException("The number cannot be less than zero!");
                }
                Console.WriteLine(Math.Sqrt(number));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.ParamName);
            }
            finally 
            {
                Console.WriteLine("Good-bye");
            }
        }
    }
}
