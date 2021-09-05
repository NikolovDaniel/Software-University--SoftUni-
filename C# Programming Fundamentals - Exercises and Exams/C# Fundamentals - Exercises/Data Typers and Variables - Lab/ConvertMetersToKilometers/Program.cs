using System;

namespace ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal meters = decimal.Parse(Console.ReadLine());

            decimal km = meters / 1000;

            Console.WriteLine($"{km:f2}");
        }
    }
}
