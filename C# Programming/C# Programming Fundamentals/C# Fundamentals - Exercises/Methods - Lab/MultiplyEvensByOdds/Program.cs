using System;

namespace MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            int result = FindOddAndEvenSum(number);
            Console.WriteLine(result);

        }

        static int FindEvenSum(int number)
        {

            int evenSum = 0;

            while (number != 0)
            {
                int even = number % 10;

                if (even % 2 == 0)
                {
                    evenSum += even;
                }

                number /= 10;
            }

            return evenSum;
        }

        static int FindOddSum(int number)
        {
            int oddSum = 0;

            while (number != 0)
            {
                int odd = number % 10;

                if (odd % 2 == 1)
                {
                    oddSum += odd;
                }

                number /= 10;
            }

            return oddSum;
        }

        static int FindOddAndEvenSum(int number)
        {
            int result = FindEvenSum(number) * FindOddSum(number);

            return result;
        }

    }
}
