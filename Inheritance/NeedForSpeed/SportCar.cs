using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class SportCar:Car
    {
        
        public double DefaultFuelConsumption = 10;
        public SportCar(int horsepower, double fuel) : base(horsepower, fuel)
        {
            base.FuelConsumption = DefaultFuelConsumption;
        }
    }
}
