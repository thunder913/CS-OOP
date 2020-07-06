using System;
using System.Linq;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            var phones = Console.ReadLine().Split().ToList();

            var smartPhone = new Smartphone();
            var stationaryPhone = new StationaryPhone();
            foreach (var number in phones)
            {
                if (number.Length == 7)
                {
                    Console.WriteLine(stationaryPhone.CallOtherPhone(number));
                }
                else 
                {
                    Console.WriteLine(smartPhone.CallOtherPhone(number));
                }
            }

            var websites = Console.ReadLine().Split().ToList();
            foreach (var site in websites)
            {
                Console.WriteLine(smartPhone.SurfTheWeb(site));
            }
        }
    }
}
