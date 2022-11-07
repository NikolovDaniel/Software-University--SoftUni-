using System;

namespace SumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] items = Console.ReadLine().Split();

            int[] numbers = new int[items.Length];

            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(items[i]);
                if (numbers[i] % 2 == 0) sum += numbers[i];
            }
            Console.WriteLine(sum);
        }
    }
}
