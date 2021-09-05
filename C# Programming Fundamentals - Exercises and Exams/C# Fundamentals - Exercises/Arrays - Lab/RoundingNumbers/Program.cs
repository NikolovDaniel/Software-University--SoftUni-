using System;

namespace RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string num  = Console.ReadLine();

            string[] items = num.Split();

            double[] numbers = new double[items.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = double.Parse(items[i]);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"{Convert.ToDecimal(numbers[i])} => {(int)Math.Round(numbers[i],MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
