using System;

namespace GreaterNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //INPUT 
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            //SOLUTION

            if (firstNumber > secondNumber)
            {
                Console.WriteLine(firstNumber);
            }
            else
            {
                Console.WriteLine(secondNumber);
            }

        }
    }
}
