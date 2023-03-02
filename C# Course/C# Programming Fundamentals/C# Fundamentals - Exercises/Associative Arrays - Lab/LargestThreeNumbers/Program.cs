using System;
using System.Linq;

namespace LargestThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                   .Split()
                                   .Select(int.Parse)
                                   .OrderByDescending(n => n)
                                   .ToArray();

            int counter = 0;

            if (numbers.Length > 3) counter = 3;
            else counter = numbers.Length;
                 
            for (int i = 0; i < counter; i++)
            {
                Console.Write($"{numbers[i]} ");

            }

        }
    }
}
