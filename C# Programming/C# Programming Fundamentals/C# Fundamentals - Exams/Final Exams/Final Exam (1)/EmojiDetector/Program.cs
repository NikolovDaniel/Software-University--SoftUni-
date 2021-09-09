using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {

            string patternEmoji = @"(\*{2}|:{2})(?<emoji>[A-Z][a-z]{2,})\1";
            string patternNumbers = @"[0-9]";

            string input = Console.ReadLine();

            MatchCollection emojis = Regex.Matches(input, patternEmoji);
            MatchCollection numbers = Regex.Matches(input, patternNumbers);

            List<string> coolEmojis = new List<string>();
            int coolThreshold = 1;

            foreach (Match match in numbers)
            {
                coolThreshold *= int.Parse(match.Value);
            }

            foreach (Match match in emojis)
            {
                string currentEmoji = match.Groups["emoji"].Value;

                int currentThreshold = 0;

                for (int i = 0; i < currentEmoji.Length; i++)
                {
                    currentThreshold += currentEmoji[i];
                }

                if (currentThreshold > coolThreshold)
                {
                    if (!coolEmojis.Contains(match.Value))
                    {
                        coolEmojis.Add(match.Value);
                    }
                }

            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");

            for (int i = 0; i < coolEmojis.Count; i++)
            {
                Console.WriteLine(coolEmojis[i]);
            }


        }
    }
}
