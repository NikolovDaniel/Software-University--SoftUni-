using System;
using System.Collections.Generic;

namespace SpeedRacing
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
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);

                Car car = new Car()
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsumptionPerKilometr = fuelConsumption,
                    TravelledDistance = 0
                };

                if (!listOfCars.Contains(car))
                {
                    listOfCars.Add(car);
                }
            }

            string inpt = Console.ReadLine();

            while (inpt != "End")
            {
                string[] tokens = inpt.Split();

                string model = tokens[1];
                double kilometers = double.Parse(tokens[2]);

                foreach (var car in listOfCars)
                {
                    if (car.Model == model)
                    {
                        car.Drive(kilometers);
                        break;
                    }
                }

                inpt = Console.ReadLine();
            }

            foreach (var car in listOfCars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
