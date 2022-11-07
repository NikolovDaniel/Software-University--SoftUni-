using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {

            string patternOne = @"(?<text>[^0-9]+)(?<number>[0-9]+)";

            Regex regexOne = new Regex(patternOne);

            string input = Console.ReadLine().ToUpper();

            HashSet<char> uniqueChars = new HashSet<char>();

            StringBuilder sb = new StringBuilder();

            MatchCollection matches = regexOne.Matches(input);

            foreach (Match match in matches)
            {
                string currentText = match.Groups["text"].Value;
                int num = int.Parse(match.Groups["number"].Value);

                if (num > 0)
                {
                    foreach (var letter in currentText)
                    {
                        uniqueChars.Add(letter);
                    }
                }

                for (int i = 0; i < num; i++)
                {
                    sb.Append(currentText);
                }

            }

            Console.WriteLine($"Unique symbols used: {uniqueChars.Count}");

            Console.WriteLine(sb.ToString());


        }
    }
}
