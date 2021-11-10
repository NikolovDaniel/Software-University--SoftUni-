using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override string Drive(double distance)
        {
            double fuelConsumption = FuelConsumption + 1.4;
            double fuelPerKm = distance * fuelConsumption;

            if (fuelPerKm > this.FuelQuantity)
            {
                return "Bus needs refueling";
            }

            this.FuelQuantity -= fuelPerKm;
            return $"Bus travelled {distance} km";
        }

        public string DriveEmpty(double distance)
        {
            double fuelPerKm = FuelConsumption * distance;

            if (fuelPerKm > this.FuelQuantity)
            {
                return "Bus needs refueling";
            }

            this.FuelQuantity -= fuelPerKm;
            return $"Bus travelled {distance} km";
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (liters + FuelQuantity > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += liters;
            }
        }
        public override string ToString()
        {
            return $"Bus: {this.FuelQuantity:f2}";
        }
    }
}
