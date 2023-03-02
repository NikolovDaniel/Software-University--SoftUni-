using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {

            double numOne = double.Parse(Console.ReadLine());
            double numTwo = double.Parse(Console.ReadLine());

            double resultNumOne = PrintFactorialNumberOne(numOne);
            double resultNuMTwo = PrintFactorialNumberTwo(numTwo);
            double endResult = resultNumOne / resultNuMTwo;

            Console.WriteLine($"{endResult:f2}");
            
        }

        static double PrintFactorialNumberOne(double numOne)
        {

            double result = numOne;

            for (double i = numOne - 1; i >= 1 ; i--)
            {
                result *= i;
            }

            return result;

        }

        static double PrintFactorialNumberTwo(double numTwo)
        {

            double result = numTwo;

            for (double i = numTwo - 1; i >= 1; i--)
            {
                result *= i;
            }

            return result;

        }
    }
}
