using System;
using System.Collections.Generic;
using System.Linq;

namespace CountCharsInString
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> charCounts = new Dictionary<char, int>();

            string[] words = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();


            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i];

                for (int a = 0; a < currentWord.Length; a++)
                {
                    if (charCounts.ContainsKey(currentWord[a]))
                    {
                        charCounts[currentWord[a]]++;
                    }
                    else
                    {
                        charCounts.Add(currentWord[a], 1);
                    }
                }
            }

            foreach (var item in charCounts)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
                           
        }
    }
}
