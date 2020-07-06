using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car:Vehicle
    {
        public double DefaultFuelConsumption = 3;

        public Car(int horsepower, double fuel) : base(horsepower, fuel)
        {
            base.FuelConsumption = DefaultFuelConsumption;
        }
    }
}
