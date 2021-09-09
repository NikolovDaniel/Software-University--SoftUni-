using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            string type = Console.ReadLine();
            string data = Console.ReadLine();

            switch (type)
            {
                case "int":

                    int resultInteger = PrintInteger(data);
                    Console.WriteLine(resultInteger);

                    break;

                case "real":

                    double resultDouble = PrintDouble(data);
                    Console.WriteLine($"{resultDouble:f2}");

                    break;

                case "string":

                    Console.WriteLine($"${data}$");

                    break;
            }

        }

        static int PrintInteger(string data)
        {

            int result = 0;
            int.TryParse(data, out result);

            result *= 2;

            return result;

        }

        static double PrintDouble(string data)
        {

            double result = 0;
            double.TryParse(data, out result);

            result *= 1.5;

            return result;

        }
    }
}
