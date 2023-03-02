using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialCars
{
    class StartUp
    {
        static void Main(string[] args)
        {

            List<Tire[]> listOfTires = new List<Tire[]>();

            string input = Console.ReadLine();


            while (input != "No more tires")
            {

                string[] tires = input.Split();

                Tire[] currTires = new Tire[4]
                {
                    new Tire(int.Parse(tires[0]), double.Parse(tires[1])),
                    new Tire(int.Parse(tires[2]), double.Parse(tires[3])),
                    new Tire(int.Parse(tires[4]), double.Parse(tires[5])),
                    new Tire(int.Parse(tires[6]), double.Parse(tires[7]))
                };

                listOfTires.Add(currTires);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            List<Engine> listOfEngines = new List<Engine>();

            while (input != "Engines done")
            {

                string[] tokens = input.Split();

                int horsePowers = int.Parse(tokens[0]);
                double cubicCapacity = double.Parse(tokens[1]);

                Engine engine = new Engine(horsePowers, cubicCapacity);

                listOfEngines.Add(engine);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            List<Car> listOfCars = new List<Car>();

            while (input != "Show special")
            {

                string[] tokens = input.Split();

                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                Car car = new Car()
                {
                    Make = make,
                    Model = model,
                    Year = year,
                    FuelQuantity = fuelQuantity,
                    FuelConsumption = fuelConsumption,
                    Tires = listOfTires[tiresIndex],
                    Engine = listOfEngines[engineIndex]
                };

                listOfCars.Add(car);

                input = Console.ReadLine();
            }

            Console.WriteLine(SpecialCars(listOfCars));

        }

        public static string SpecialCars(List<Car> cars)
        {
            List<Car> specialCars = cars.Where(c => c.Year >= 2017)
                .Where(c => c.Engine.HorsePower >= 330)
                .Where(c => c.Tires.Sum(y => y.Pressure) >= 9 && c.Tires.Sum(y => y.Pressure) <= 10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var car in specialCars)
            {
                car.Drive(20);
                sb.AppendLine($"Make: {car.Make}");
                sb.AppendLine($"Model: {car.Model}");
                sb.AppendLine($"Year: {car.Year}");
                sb.AppendLine($"HorsePowers: {car.Engine.HorsePower}");
                sb.AppendLine($"FuelQuantity: {car.FuelQuantity}");
            }

            return sb.ToString();
        }
    }
}
