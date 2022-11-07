using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            string pattern = @"([=]|[/])(?<destination>[A-Z][A-Za-z]{2,})\1";

            List<string> validDestinations = new List<string>();

            int points = 0;

            MatchCollection destinations = Regex.Matches(input, pattern);

            if (destinations.Count > 0)
            {
                foreach (Match match in destinations)
                {
                    validDestinations.Add(match.Groups["destination"].Value);
                    points += match.Groups["destination"].Value.Length;
                }
            }

            Console.WriteLine($"Destinations: {string.Join(", ", validDestinations)}");
            Console.WriteLine($"Travel Points: {points}");

        }
    }
}
