using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class FamilyCar:Car
    {
        public FamilyCar(int horsepower, double fuel) : base(horsepower, fuel)
        {
            base.FuelConsumption = DefaultFuelConsumption;
        }
    }
}
