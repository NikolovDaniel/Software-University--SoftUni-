using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<Car> listOfCars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                double cargoWeight = double.Parse(input[3]);
                string cargoType = input[4];
                double tireOnePressure = double.Parse(input[5]);
                int tireOneAge = int.Parse(input[6]);
                double tireTwoPressure = double.Parse(input[7]);
                int tireTwoAge = int.Parse(input[8]);
                double tireThreePressure = double.Parse(input[9]);
                int tireThreeAge = int.Parse(input[10]);
                double tireFourPressure = double.Parse(input[11]);
                int tireFourAge = int.Parse(input[12]);

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType,
                    tireOnePressure, tireOneAge, tireTwoPressure, tireTwoAge, tireThreePressure, 
                    tireThreeAge, tireFourPressure, tireFourAge);

                listOfCars.Add(car);
            }

            string fragileOrFlamable = Console.ReadLine();

            if (fragileOrFlamable == "fragile")
            {
                listOfCars.Where(c => c.Cargo.Type == "fragile")
                     .Where(c => c.Tires.Any(p => p.Pressure < 1))
                     .ToList()
                     .ForEach(c => Console.WriteLine(c.Model));
            }
            else if (fragileOrFlamable == "flammable" || fragileOrFlamable == "flamable")
            {
                   listOfCars.Where(c => c.Cargo.Type == "flammable")
                   .Where(c => c.Engine.EnginePower > 250)
                   .ToList()
                   .ForEach(c => Console.WriteLine(c.Model));
            }
        }
    }
}
