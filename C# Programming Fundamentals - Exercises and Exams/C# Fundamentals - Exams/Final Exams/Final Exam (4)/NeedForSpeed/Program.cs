using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeed
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string input = string.Empty;

            Dictionary<string, List<int>> cars = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();

                string[] commands = input.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string car = commands[0];
                int mileage = int.Parse(commands[1]);
                int fuel = int.Parse(commands[2]);

                cars.Add(car, new List<int>() { mileage, fuel });

            }

            input = Console.ReadLine();

            while (input != "Stop")
            {

                string[] commands = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string cmdOne = commands[0];

                if (cmdOne == "Drive")
                {
                    string car = commands[1];
                    int distance = int.Parse(commands[2]);
                    int fuel = int.Parse(commands[3]);

                    if ((cars[car][1] - fuel) <= 0)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        cars[car][0] += distance;
                        cars[car][1] -= fuel;
                    }

                    if (cars[car][0] >= 100000) 
                    {
                        Console.WriteLine($"Time to sell the {car}!");
                        cars.Remove(car);
                    }

                }
                else if (cmdOne == "Refuel")
                {
                    string car = commands[1];
                    int fuel = int.Parse(commands[2]);

                    if ((cars[car][1] + fuel) > 75)
                    {
                        Console.WriteLine($"{car} refueled with {75 - cars[car][1]} liters");
                        cars[car][1] = 75;
                    }
                    else
                    {
                        Console.WriteLine($"{car} refueled with {fuel} liters");
                        cars[car][1] += fuel;
                    }

                }
                else if (cmdOne == "Revert")
                {
                    string car = commands[1];
                    int kilometers = int.Parse(commands[2]);

                    cars[car][0] -= kilometers;

                    Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");

                    if (cars[car][0] < 10000)
                    {
                        cars[car][0] = 10000;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var car in cars.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");
            }

        }
    }
}
