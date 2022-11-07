using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public abstract string Drive(double distance);

        public abstract void Refuel(double liters);

    }
}
