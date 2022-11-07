using System;

namespace AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());

            int result = PrintSum(numberOne, numberTwo, numberThree);

            Console.WriteLine(result);

        }

        static int PrintSum(int numberOne, int numberTwo, int numberThree)
        {

            int sumNumbers = (numberOne + numberTwo) - numberThree;

            return sumNumbers;

        }

    }
}
