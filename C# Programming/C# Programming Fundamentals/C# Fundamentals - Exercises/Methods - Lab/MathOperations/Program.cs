using System;

namespace MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {

            double numOne = double.Parse(Console.ReadLine());
            string operators = Console.ReadLine();
            double numTwo = double.Parse(Console.ReadLine());

            double result = CalculateNums(numOne, operators, numTwo);
            Console.WriteLine(result);  

        }

        static double CalculateNums(double numOne, string operators, double numTwo)
        {

            double result = 0;

            switch (operators)
            {
                case "/": result = numOne / numTwo; break;
                case "*":result = numOne * numTwo; break;
                case "+":result = numOne + numTwo; break;
                case "-": result = numOne - numTwo; break;
            }

            return result;
        }
    }
    
}
