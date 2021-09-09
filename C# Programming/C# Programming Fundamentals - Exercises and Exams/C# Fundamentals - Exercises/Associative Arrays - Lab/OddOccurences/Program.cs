using System;
using System.Collections.Generic;
using System.Linq;

namespace OddOccurences
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> oddOccurences = new Dictionary<string, int>();

            string[] input = Console.ReadLine().ToLower().Split().ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                if (oddOccurences.ContainsKey(input[i]))
                {
                    oddOccurences[input[i]]++;
                }
                else
                {
                    oddOccurences.Add(input[i], 1);
                }
            }

            foreach (var item in oddOccurences)
            {
                if (item.Value % 2 == 1)
                {
                    Console.Write($"{item.Key} ");
                }
            }
        }
    }
}
