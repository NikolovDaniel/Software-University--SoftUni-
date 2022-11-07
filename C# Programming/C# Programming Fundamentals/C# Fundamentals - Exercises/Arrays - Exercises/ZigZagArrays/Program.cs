using System;
using System.Linq;

namespace ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arrayOne = new int[n];
            int[] arrayTwo = new int[n];

            int counter = 0;
            int counterArray = 0;

            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (counterArray % 2 == 0)
                {
                    arrayOne[counter] = numbers[0];
                    arrayTwo[counter] = numbers[0 + 1];                   
                }
                else
                {
                    arrayOne[counter] = numbers[0 + 1];
                    arrayTwo[counter] = numbers[0];                  
                }
                counterArray++;
                counter++;
            }
            Console.WriteLine(string.Join(" ", arrayOne));
            Console.WriteLine(string.Join(" ", arrayTwo));
        }
    }
}
