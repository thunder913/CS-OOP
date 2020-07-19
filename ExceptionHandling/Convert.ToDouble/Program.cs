using System;
using System.Threading;

namespace Convert.ToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var input = Console.ReadLine();
                var converted = System.Convert.ToDouble(input);
                Console.WriteLine("The converted number is: " + converted);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch(OverflowException oe) 
            {
                Console.WriteLine(oe.Message);
            }
        }
    }
}
