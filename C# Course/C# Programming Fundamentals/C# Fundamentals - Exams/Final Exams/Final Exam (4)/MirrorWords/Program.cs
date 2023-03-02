using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([@]|[#])(?:(?<wordOne>[A-Za-z]{3,})\1\1(?<wordTwo>[A-Za-z]{3,}))\1";

            string input = Console.ReadLine();

            Dictionary<string, string> matchWords = new Dictionary<string, string>();

            MatchCollection words = Regex.Matches(input, pattern);

            
            foreach (Match match in words)
            {

                string wordOne = match.Groups["wordOne"].Value;
                string wordTwo = match.Groups["wordTwo"].Value;

                string reversedOne = string.Empty;
                string reversedTwo = string.Empty;

                if (wordOne.Length == wordTwo.Length)
                {
                    for (int i = wordOne.Length - 1; i >= 0; i--)
                    {
                        reversedOne += wordOne[i].ToString();
                        reversedTwo += wordTwo[i].ToString();
                    }
                }

                if (reversedOne == wordTwo || reversedTwo == wordOne)
                {
                    if (!matchWords.ContainsKey(wordOne)) 
                    {
                        matchWords.Add(wordOne, wordTwo);
                    }
                }
            }

            if (words.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{words.Count} word pairs found!");
            }


            List<string> result = new List<string>();

            if (matchWords.Count > 0)
            {
                Console.WriteLine("The mirror words are:");

                foreach (var item in matchWords)
                {
                    result.Add($"{item.Key} <=> {item.Value}");
                }

                Console.WriteLine(string.Join(", ", result));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }

        }
    }
}
