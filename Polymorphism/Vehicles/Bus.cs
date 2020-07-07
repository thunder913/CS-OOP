using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private double passangerConsumption { get; set; }
        private double emptyConsmption { get; set; }
        public Bus(double fuel, double fuelConsumption, double capacitiy) : base(fuel, fuelConsumption, capacitiy)
        {
            this.emptyConsmption = FuelConsumption;
            this.passangerConsumption = emptyConsmption + 1.4;
        }

        public string DriveEmpty(double distance) 
        {
            this.FuelConsumption = emptyConsmption;
            return base.Drive(distance);
        }

        public override string Drive(double distance) 
        {
            this.FuelConsumption = passangerConsumption;
            return base.Drive(distance);
        }
    }
}
