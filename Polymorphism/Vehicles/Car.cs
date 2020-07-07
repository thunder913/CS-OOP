using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    class Car : Vehicle
    {
        private const double consumptionModifier = 0.9;
        public Car(double fuel, double consumption, double capacity) : base(fuel, consumption+consumptionModifier, capacity) { }

    }
}
