using System;

namespace Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            
            int maxDivisible = 0;

            if (number % 2 == 0) maxDivisible = 2;
            if (number % 3 == 0) maxDivisible = 3;
            if (number % 6 == 0) maxDivisible = 6;
            if (number % 7 == 0) maxDivisible = 7;
            if (number % 10 == 0) maxDivisible = 10;

            if (number % 2 == 0 && number % 3 == 0) maxDivisible = 6;
            if (number % 2 == 0 && number % 10 == 0) maxDivisible = 10;

            if (maxDivisible == 0)
            {
                Console.WriteLine("Not divisible");
            }
            else
            {
                Console.WriteLine($"The number is divisible by {maxDivisible}");
            }
        } 
    }
}
