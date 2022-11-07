using System;

namespace ExactSumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            decimal[] array = new decimal[n];
            decimal sum = 0;

            for (int i = 0; i < n; i++)
            {
                array[i] = decimal.Parse(Console.ReadLine());

            }
            foreach (decimal numbers in array)
            {
                sum += numbers;
            }

            Console.WriteLine(sum);
        }
    }
}
