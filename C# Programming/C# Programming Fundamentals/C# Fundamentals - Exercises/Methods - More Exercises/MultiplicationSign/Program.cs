using System;

namespace MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {

            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numThree = int.Parse(Console.ReadLine());

            PrintSign(numOne, numTwo, numThree);

        }

        static void PrintSign(int numOne, int numTwo, int numThree)
        {

            int counter = 0;
            int counterZero = 0;
            int[] array = { numOne, numTwo, numThree };

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0) counter++;
                if (array[i] == 0) counterZero++;
            }

            if (counterZero >= 1) Console.WriteLine("zero");
            else if (counter == 2 || counter == 0) Console.WriteLine("positive");
            else Console.WriteLine("negative");

        }
    }
}
