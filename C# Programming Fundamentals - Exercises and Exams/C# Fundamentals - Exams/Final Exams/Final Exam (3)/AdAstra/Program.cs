using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([|]|[#])(?<item>[A-Za-z ]+)\1(?<expiration>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d{1,5})\1";

            string input = Console.ReadLine();

            int daysFood = 0;

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                daysFood += int.Parse(match.Groups["calories"].Value);
            }

            daysFood /= 2000;

            Console.WriteLine($"You have food to last you for: {daysFood} days!");

            foreach (Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups["item"].Value}, Best before: {match.Groups["expiration"].Value}, Nutrition: {match.Groups["calories"].Value}");
            }
        }
    }
}

