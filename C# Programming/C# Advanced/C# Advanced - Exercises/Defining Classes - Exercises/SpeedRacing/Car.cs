using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometr { get; set; }
        public double TravelledDistance { get; set; }


        public void Drive(double kilometers)
        {

            if (FuelAmount - (FuelConsumptionPerKilometr * kilometers) >= 0)
            {
                this.FuelAmount -= FuelConsumptionPerKilometr * kilometers;
                TravelledDistance += kilometers;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
