using System;
using System.Runtime.CompilerServices;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            var carDetails = Console.ReadLine().Split();
            var truckDetails = Console.ReadLine().Split();
            var busDetails = Console.ReadLine().Split();
            
            var car = new Car(double.Parse(carDetails[1]), double.Parse(carDetails[2]), double.Parse(carDetails[3]));
            var truck = new Truck(double.Parse(truckDetails[1]), double.Parse(truckDetails[2]),double.Parse(truckDetails[3]));
            var bus = new Bus(double.Parse(busDetails[1]), double.Parse(busDetails[2]),double.Parse(busDetails[3]));

            var commands = int.Parse(Console.ReadLine());
            for (int i = 0; i < commands; i++)
            {
                var command = Console.ReadLine().Split();
                var vehicleType = command[1];
                try
                {
                    if (command[0] == "Drive")
                    {
                        var distance = double.Parse(command[2]);
                        if (vehicleType == "Car")
                        {
                            Console.WriteLine(car.Drive(distance));
                        }
                        else if (vehicleType == "Truck")
                        {
                            Console.WriteLine(truck.Drive(distance));
                        }
                        else if (vehicleType == "Bus")
                        {
                            Console.WriteLine(bus.Drive(distance));
                        }
                    }
                    else if (command[0] == "Refuel")
                    {
                        var fuel = double.Parse(command[2]);
                        if (vehicleType == "Car")
                        {
                            car.Refuel(fuel);
                        }
                        else if(vehicleType == "Truck")
                        {
                            truck.Refuel(fuel);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(fuel);
                        }
                    }
                    else if(command[0] == "DriveEmpty")
                    {
                        var distance = double.Parse(command[2]);
                        Console.WriteLine(bus.DriveEmpty(distance));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
