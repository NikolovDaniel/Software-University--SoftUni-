using System;

namespace MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int raisedBy = int.Parse(Console.ReadLine());

            double result = PrintNumberPower(number, raisedBy);

            Console.WriteLine(result);
        }

        static double PrintNumberPower(double number, int raisedBy)
        {
            double result = Math.Pow(number, raisedBy);
            return result;
        }
    }
}
