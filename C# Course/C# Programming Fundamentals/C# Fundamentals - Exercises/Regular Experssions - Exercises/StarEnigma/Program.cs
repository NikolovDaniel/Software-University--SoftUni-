using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string patternOne = @"[STARstar]";
            string patternTwo = @"\@(?<planet>[A-Za-z]+)[^@\-!:]*?:(?<population>\d+)[^@\-!:]*?!(?<attackType>[A]|[D])![^@\-!:]*?->[^@\-!:]*?(?<soldiers>\d+)";

            Regex regexOne = new Regex(patternOne);
            Regex regexTwo = new Regex(patternTwo);

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                MatchCollection letters = regexOne.Matches(input);

                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < input.Length; j++)
                {
                    sb.Append((char)(input[j] - letters.Count));
                }


                MatchCollection planets = regexTwo.Matches(sb.ToString());

                foreach (Match match in planets)
                {
                    var defOrAttack = match.Groups["attackType"].Value;
                    var planetName = match.Groups["planet"].Value;
                    var population = match.Groups["population"].Value;
                    var soldiers = match.Groups["soldiers"].Value;

                    if (defOrAttack == "A")
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }

            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            foreach (var item in attackedPlanets.OrderBy(x => x)) 
            {
                Console.WriteLine($"-> {item}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (var item in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }

        }
    }
}
