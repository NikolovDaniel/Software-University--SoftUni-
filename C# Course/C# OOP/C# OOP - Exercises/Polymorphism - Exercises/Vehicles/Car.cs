using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {

        }

        public override string Drive(double distance)
        {
            double fuelConsumption = FuelConsumption + 0.9;
            double fuelPerKm = distance * fuelConsumption;

            if (fuelPerKm > this.FuelQuantity)
            {
                return "Car needs refueling";
            }

            this.FuelQuantity -= fuelPerKm;
            return $"Car travelled {distance} km";
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"Car: {this.FuelQuantity:f2}";
        }
    }
}
