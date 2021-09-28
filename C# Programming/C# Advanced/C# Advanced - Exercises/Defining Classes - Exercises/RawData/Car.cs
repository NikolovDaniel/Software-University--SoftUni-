using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }

        public Car(string model, int engineSpeed, int enginePower, double cargoWeight, string cargoType,
         double tireOnePressure, int tireOneAge, double tireTwoPressure, int tireTwoAge, double tireThreePressure, int tireThreeAge,
         double tireFourPressure, int tireFourAge)
        {
            this.Model = model;
            this.Engine = new Engine(engineSpeed, enginePower);
            this.Cargo = new Cargo(cargoWeight, cargoType);
            this.Tires = new Tire[4]
            {
                new Tire(tireOneAge, tireOnePressure),
                new Tire(tireTwoAge, tireTwoPressure),
                new Tire(tireThreeAge, tireThreePressure),
                new Tire(tireFourAge, tireFourPressure),
            };
        }
    }
}
