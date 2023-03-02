using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string[] input = Console.ReadLine().Split(", ");

            while (input[0] != "END")
            {

                if (input[0] == "IN")
                {
                    cars.Add(input[1]);
                }
                else if (input[0] == "OUT")
                {
                    cars.Remove(input[1]);
                }

                input = Console.ReadLine().Split(", ");
            }

            if (cars.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
