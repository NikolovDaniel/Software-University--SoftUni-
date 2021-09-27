using System;
using System.Collections.Generic;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<Engine> listOfEngines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new Engine();

                string model = input[0];
                int power = int.Parse(input[1]);
                string displacement = "n/a";
                string efficiency = "n/a";

                if (input.Length == 3)
                {
                    if (int.TryParse(input[2], out int parser))
                    {
                        displacement = input[2];
                    }
                    else
                    {
                        efficiency = input[2];
                    }
                }
                else if (input.Length == 4)
                {
                    displacement = input[2];
                    efficiency = input[3];
                }

                engine = new Engine()
                {
                    Model = model,
                    Power = power,
                    Displacement = displacement,
                    Efficiency = efficiency
                };

                listOfEngines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            List<Car> listOfCars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                string engine = input[1];
                string weight = "n/a";
                string color = "n/a";

                if (input.Length == 3)
                {
                    if (double.TryParse(input[2], out double parser))
                    {
                        weight = input[2];
                    }
                    else
                    {
                        color = input[2];
                    }
                }
                else if (input.Length == 4)
                {
                    weight = input[2];
                    color = input[3];
                }

                Car car = new Car();

                foreach (var eng in listOfEngines)
                {
                    if (eng.Model == engine)
                    {
                        car = new Car()
                        {
                            Model = model,
                            Engine = eng,
                            Weight = weight,
                            Color = color
                        };
                    }
                }

                listOfCars.Add(car);
            }

            foreach (var car in listOfCars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}
