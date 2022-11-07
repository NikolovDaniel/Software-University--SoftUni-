using System;

namespace TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());

            PrintTopNumber(number);
            
        }
      
        static void PrintTopNumber(int number)
        {

            for (int i = 1; i <= number ; i++)
            {
                if (PrintIsOneDigitOdd(i) && PrintIsSumDivisibleByEight(i)) Console.WriteLine(i);
            }

        }

        static bool PrintIsSumDivisibleByEight(int number)
        {

            int digitSum = 0;

            while(number > 0)
            {
                digitSum += number % 10;
                number /= 10;
            }

            if (digitSum % 8 == 0) return true;

            return false;

        }

        static bool PrintIsOneDigitOdd(int number)
        {

            int odd = 0;
            
            while (number > 0)
            {
                odd = number % 10;
                number /= 10;

                if (odd % 2 == 1) return true;
            }

            return false;

        }
    }
}
