using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {

        }

        public override string Drive(double distance)
        {
            double fuelConsumption = FuelConsumption + 1.6;
            double fuelPerKm = distance * fuelConsumption;

            if (fuelPerKm > this.FuelQuantity)
            {
                return "Truck needs refueling";
            }

            this.FuelQuantity -= fuelPerKm;
            return $"Truck travelled {distance} km";
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters * 0.95;
        }
        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:f2}";
        }
    }
}
