using System;

namespace SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int totalSum = 0;
            int counter = 0;
            for (int i = 1; i < 100; i++)
            {
                if (i % 2 == 1)
                {
                    totalSum += i;
                    counter++;
                    Console.WriteLine(i);
                }
                if (counter == n) break;
            }
            Console.WriteLine($"Sum: {totalSum}");
        }
    }
}
