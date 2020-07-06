using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class Motorcycle:Vehicle
    {
        public Motorcycle(int horsepower, double fuel) : base(horsepower, fuel)
        {
            base.FuelConsumption = DefaultFuelConsumption;
        }
    }
}
