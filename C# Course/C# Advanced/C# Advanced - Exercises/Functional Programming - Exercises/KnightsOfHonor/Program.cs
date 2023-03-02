using System;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> concatenate = w => Console.WriteLine($"Sir {w}"); 

            string[] words = Console.ReadLine().Split();

            for (int i = 0; i < words.Length; i++)
            {
                concatenate(words[i]);
            }


            //OR THIS
            //Console.ReadLine().Split()
            //     .Select(p => $"Sir {p}")
            //     .ToList()
            //     .ForEach(p => Console.WriteLine(p));
        }
    }
}
