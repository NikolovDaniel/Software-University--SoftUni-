using System;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string calculator = Console.ReadLine();
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());

            if (calculator == "add")
            {
                Add(numOne, numTwo);
            }
            else if(calculator == "multiply")
            {
                Multiply(numOne, numTwo);
            }
            else if(calculator == "subtract")
            {
                Subtract(numOne, numTwo);
            }
            else if(calculator == "divide")
            {
                Divide(numOne, numTwo);
            }

        }  
        static void Add(int numOne, int numTwo)
        {
            Console.WriteLine(numOne + numTwo);
        }
        static void Multiply(int numOne, int numTwo)
        {
            Console.WriteLine(numOne * numTwo);
        }
        static void Subtract(int numOne, int numTwo)
        {
            Console.WriteLine(numOne - numTwo);
        }
        static void Divide(int numOne, int numTwo)
        {
            Console.WriteLine(numOne / numTwo);
        }
    }
}
