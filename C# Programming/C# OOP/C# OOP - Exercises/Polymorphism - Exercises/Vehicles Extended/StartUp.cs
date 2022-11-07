using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "Drive")
                {
                    if (input[1] == "Car")
                    {
                        Console.WriteLine(car.Drive(double.Parse(input[2])));
                    }
                    else if (input[1] == "Truck")
                    {
                        Console.WriteLine(truck.Drive(double.Parse(input[2])));
                    }
                    else
                    {
                        Console.WriteLine(bus.Drive(double.Parse(input[2])));
                    }
                }
                else if (input[0] == "Refuel")
                {
                    if (input[1] == "Car")
                    {
                        car.Refuel(double.Parse(input[2]));
                    }
                    else if (input[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(input[2]));
                    }
                    else
                    {
                        bus.Refuel(double.Parse(input[2]));
                    }
                }
                else
                {
                    Console.WriteLine(bus.DriveEmpty(double.Parse(input[2]))); 
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
