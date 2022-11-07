using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {

            string pattern = @"[A-Za-z]";
            string patternTwo = @"[0-9]";

            Regex regexOne = new Regex(pattern);
            Regex regexTwo = new Regex(patternTwo);

            List<string> names = Console.ReadLine().Split(", ").ToList();
            Dictionary<string, int> playerScores = new Dictionary<string, int>();

            string code = Console.ReadLine();

            while (code != "end of race")
            {
                int score = 0;
                StringBuilder sb = new StringBuilder();
                MatchCollection letters = regexOne.Matches(code);
                MatchCollection numbers = regexTwo.Matches(code);


                foreach (Match match in letters)
                {
                    sb.Append(match);
                }

                if (!names.Contains(sb.ToString()))
                {
                    code = Console.ReadLine();
                    continue;
                }

                string currentPlayer = sb.ToString();

                foreach (Match match in numbers)
                {
                    score += int.Parse(match.ToString());
                }

                if (playerScores.ContainsKey(currentPlayer))
                {
                    playerScores[currentPlayer] += score;
                }
                else
                {
                    playerScores.Add(currentPlayer, score);
                }


                code = Console.ReadLine();
            }

            int counter = 1;

            foreach (var item in playerScores.OrderByDescending(x => x.Value))
            {

                if (counter == 1)
                {
                    Console.WriteLine($"1st place: {item.Key}");
                }
                else if (counter == 2)
                {
                    Console.WriteLine($"2nd place: {item.Key}");
                }
                else if (counter == 3)
                {
                    Console.WriteLine($"3rd place: {item.Key}");

                    break;
                }

                counter++;

            }
        }
    }
}
