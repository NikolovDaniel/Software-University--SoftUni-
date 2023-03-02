using System;
using System.Linq;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = msg => Console.WriteLine(msg);

            string[] words = Console.ReadLine().Split();

            for (int i = 0; i < words.Length; i++)
            {
                print(words[i]);
            }

            //OR THIS
            //Console.ReadLine().Split()
            //    .ToList()
            //    .ToList()
            //    .ForEach(n => Console.WriteLine(n));
                
        }
    }
}
