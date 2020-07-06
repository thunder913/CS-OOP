namespace NeedForSpeed
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new Car(50, 45);
            Console.WriteLine(car.DefaultFuelConsumption);
        }
    }
}
