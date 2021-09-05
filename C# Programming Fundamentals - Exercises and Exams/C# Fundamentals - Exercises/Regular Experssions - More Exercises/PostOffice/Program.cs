using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternOne = @"((?:[#])|(?:[$])|(?:[%])|(?:[*])|(?:[&]))(?<letters>[A-Z]{1,})\1";
            string patternTwo = @"(?<asciicode>[0-9][0-9]):(?<length>[0-9]{2})";

            Regex regexOne = new Regex(patternOne);
            Regex regexTwo = new Regex(patternTwo);

            Dictionary<string, List<int>> items = new Dictionary<string, List<int>>();
            List<int> ascii = new List<int>();
            List<int> lengths = new List<int>();
            List<string> result = new List<string>();

            string[] input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

            string textOne = input[0];
            string textTwo = input[1];
            string textThree = input[2];

            Match letters = regexOne.Match(textOne);
            MatchCollection numbers = regexTwo.Matches(textTwo);

            string allLetters = letters.Groups["letters"].Value;


            foreach (Match match in numbers)
            {
                if (!ascii.Contains(int.Parse(match.Groups["asciicode"].Value)))
                {
                    ascii.Add(int.Parse(match.Groups["asciicode"].Value));
                    lengths.Add(int.Parse(match.Groups["length"].Value));
                }
            }

            for (int i = 0; i < allLetters.Length; i++)
            {

                for (int j = 0; j < ascii.Count; j++)
                {

                    if (ascii[j] == allLetters[i])
                    {
                        items.Add(allLetters[i].ToString(), new List<int>() { ascii[j], lengths[j] });
                    }
                }
            }


            string[] allWords = textThree.Split(' ');


            foreach (var item in items)
            {
                for (int i = 0; i < allWords.Length; i++)
                {
                    string currWord = allWords[i];

                    if (item.Key == currWord[0].ToString() && item.Value[1] + 1 == currWord.Length)
                    {
                        result.Add(currWord);
                    }
                }
            }

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }

        }
    }
}
