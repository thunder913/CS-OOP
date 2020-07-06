using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class RaceMotorcycle:Motorcycle
    {
        public double DefaultFuelConsumption = 8;
        public RaceMotorcycle(int horsepower, double fuel) : base(horsepower, fuel)
        {
            base.FuelConsumption = DefaultFuelConsumption;
        }
    }
}
