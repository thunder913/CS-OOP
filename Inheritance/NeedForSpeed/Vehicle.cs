using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        public virtual double FuelConsumption { get; set; }
        public double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsepower, double fuel) 
        {
            this.HorsePower = horsepower;
            this.Fuel = fuel;
        }
        public virtual void Drive(double kilometres)
        {
            Fuel -= kilometres * FuelConsumption;
        }

    }
}
