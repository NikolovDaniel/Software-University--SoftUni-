using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bomb = array[0];
            int power = array[1];


            for (int i = 0; i < numbers.Count; i++)
            {

                if (numbers[i] == bomb)
                {

                    int startIndex = i - power;
                    int endIndex = i + power;

                    if (startIndex < 0) startIndex = 0;
                    if (endIndex > numbers.Count - 1) endIndex = numbers.Count - 1;

                    int endIndexToRemove = endIndex - startIndex + 1;
                    numbers.RemoveRange(startIndex, endIndex);

                    i = startIndex - 1;
                }

            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
