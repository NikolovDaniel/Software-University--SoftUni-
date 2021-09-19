using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Dictionary<char, int> charCount = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (charCount.ContainsKey(input[i]))
                {
                    charCount[input[i]]++;
                }
                else
                {
                    charCount.Add(input[i], 1);
                }
            }

            foreach (var ch in charCount.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }

        }
    }
}
