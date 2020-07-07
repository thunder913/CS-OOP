using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuel, double fuelConsumption, double capacity)
        {
            this.TankCapacity = capacity;
            this.FuelConsumption = fuelConsumption;
            if (fuel > this.TankCapacity)
            {
                this.Fuel = 0;
            }
            else
            {
                this.Fuel = fuel;
            }
        }

        public double TankCapacity { get; set; }
        public double Fuel { get; set; }
        public double FuelConsumption { get; set; }

       
        public virtual string Drive(double distance )
        {
            if (this.Fuel >= this.FuelConsumption * distance)
            {
                this.Fuel -= this.FuelConsumption * distance;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public virtual void Refuel(double fuel)
        {
            FuelCheck(fuel);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Fuel:F2}";
        }

        private void FuelCheck(double fuel) 
        {
            if (fuel<=0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }
            else if (this.Fuel+fuel > TankCapacity)
            {
                throw new Exception($"Cannot fit {fuel} fuel in the tank");
            }
            this.Fuel += fuel;
        }
    }
}
