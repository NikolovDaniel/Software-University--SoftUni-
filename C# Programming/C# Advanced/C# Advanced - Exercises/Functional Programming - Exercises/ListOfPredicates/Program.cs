using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();

            List<int> result = new List<int>();

            bool isValid = false;

            for (int i = 1; i <= range; i++)
            {
                for (int j = 0; j < dividers.Length; j++)
                {
                    Predicate<int> predicate = n => n % dividers[j] == 0;

                    if (predicate(i))
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
