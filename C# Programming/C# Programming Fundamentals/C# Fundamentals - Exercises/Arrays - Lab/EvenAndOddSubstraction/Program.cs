using System;

namespace EvenAndOddSubstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] items = Console.ReadLine().Split();
            int[] numbers = new int[items.Length];

            int evenSum = 0;
            int oddSum = 0;
            int result = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(items[i]);
                if (numbers[i] % 2 == 0) evenSum += numbers[i];
                else oddSum += numbers[i];
            }
            result = (evenSum - oddSum);
            Console.WriteLine(result);
        }
    }
}
