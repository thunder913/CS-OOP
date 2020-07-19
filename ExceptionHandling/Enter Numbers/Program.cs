using System;
using System.Collections.Generic;
using System.Linq;

namespace Enter_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You will have to enter numbers. They must be between 0 and 100.");
            Console.WriteLine("Also every number should be greater than the previous!");
            while (!GetSumOf10Numbers())
            {
                Console.WriteLine("Try again!");
            }
        }

        public static bool GetSumOf10Numbers() 
        {
            var numbers = new List<int>();
            var min = 1;
            var max = 100;
            var previousNumber = -1;
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    var currentNumber = int.Parse(Console.ReadLine());
                    if (previousNumber > currentNumber)
                    {
                        throw new InvalidOperationException();
                    }
                    if (min > currentNumber || currentNumber > max)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    previousNumber = currentNumber;
                    numbers.Add(currentNumber);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("You entered an invalid number!");
                    return (false);
                }
                catch (FormatException)
                {
                    Console.WriteLine("You entered an inparsable number!");
                    return false;
                }
                catch (OverflowException) 
                {
                    Console.WriteLine("You entered too big numbers!");
                    return false;
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Every number should be greater than the previous");
                    return false;
                }
                catch (ArgumentOutOfRangeException) 
                {
                    Console.WriteLine("The number must be between 0 and 100");
                    return false;
                }
            }

            Console.WriteLine("The sum of all the entered numbers is: " + numbers.Sum());
            return true;
        }
    }
}
