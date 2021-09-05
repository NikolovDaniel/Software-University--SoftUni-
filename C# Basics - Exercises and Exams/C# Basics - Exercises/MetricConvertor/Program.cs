using System;

namespace MetricConvertor
{
    class Program
    {
        static void Main(string[] args)
        {
            //INPUT
            double number = double.Parse(Console.ReadLine());
            string inputUnit = Console.ReadLine();
            string outputUnit = Console.ReadLine();
            double result = 0.0;

            //SOLUTION = MILIMETERS
            if (inputUnit == "mm" && outputUnit == "m")
            {
                result = number / 1000;
                Console.WriteLine($"{result:f3}");
            }
            else if (inputUnit == "mm" && outputUnit == "cm")
            {
                result = number / 10;
                Console.WriteLine($"{result:f3}");
            }

            //SOLUTION = CENTIMETERS
            if (inputUnit == "cm" && outputUnit == "m")
            {
                result = number / 100;
                Console.WriteLine($"{result:f3}");
            }
            else if (inputUnit == "cm" && outputUnit == "mm")
            {
                result = number * 10;
                Console.WriteLine($"{result:f3}");
            }

            //SOLUTION = METERS
            if (inputUnit == "m" && outputUnit == "mm")
            {
                result = number * 1000;
                Console.WriteLine($"{result:f3}");
            }
            else if (inputUnit == "m" && outputUnit == "cm")
            {
                result = number * 100;
                Console.WriteLine($"{result:f3}");
            }
        }
    }
}
