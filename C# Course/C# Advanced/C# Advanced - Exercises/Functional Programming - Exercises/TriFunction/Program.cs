using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read Sum.
            int n = int.Parse(Console.ReadLine());

            //Read words from the console and put them in an Array.
            string[] words = Console.ReadLine().Split();

            //Create a function, which gets the names, whose sum of chars is equal or higher than the Sum.
            Func<string, int, bool> predicate = (name, count) => name.ToCharArray().Select(n => (int)n).ToList().Sum() >= n;

            //Create a function to print the first name that meets the requirement.
            Func<string[], int, Func<string, int, bool>, string> firstValidName = (arr, num, func) => arr.FirstOrDefault(str => func(str, num));

            //Prints the name on the console.
            Console.WriteLine(firstValidName(words, n, predicate));
        }
    }
}
