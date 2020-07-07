using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Vehicles
{
    class Truck : Vehicle
    {
        private const double FuelModifier = 0.95;
        private const double consumptionModifier = 1.6;

        public Truck(double fuel, double consumption, double capacity) : base(fuel, consumption + consumptionModifier, capacity) { }

        public override void Refuel(double fuel)
        {
            try
            {
                base.Refuel(fuel * FuelModifier);
            }
            catch (ArgumentException aex)
            {
                throw new ArgumentException(aex.Message);
            }
            catch (Exception)
            {
                throw new Exception($"Cannot fit {fuel} fuel in the tank");
            }
        }
    }
}
