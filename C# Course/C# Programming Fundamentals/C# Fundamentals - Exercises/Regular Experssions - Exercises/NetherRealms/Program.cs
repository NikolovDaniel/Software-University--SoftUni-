using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {



            string patternOne = @"([^\d\+\-*\/\."" ""])";
            string patternTwo = @"([-]|[+]{1})?[0-9]+\.*[0-9]*";
            string patternThree = @"[\/*]";

            Regex regexOne = new Regex(patternOne);
            Regex regexTwo = new Regex(patternTwo);
            Regex regexThree = new Regex(patternThree);

            Dictionary<string, List<double>> demons = new Dictionary<string, List<double>>();


            string[] demonNames = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < demonNames.Length; i++)
            {
                MatchCollection healthPoints = regexOne.Matches(demonNames[i]);

                int health = CalculateHealth(healthPoints, regexOne, demonNames[i]);
                
                MatchCollection damagePoints = regexTwo.Matches(demonNames[i]);

                double damage = CalculateDamage(damagePoints, regexTwo, regexThree, demonNames[i]);

                demons.Add(demonNames[i], new List<double>() { health, damage });
            }

            foreach (var demon in demons.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{demon.Key} - {demon.Value[0]} health, {demon.Value[1]:f2} damage");
            }

        }

        static int CalculateHealth(MatchCollection healthPoints, Regex regexOne, string name)
        {

            int health = 0;

            healthPoints = regexOne.Matches(name);

            foreach (Match match in healthPoints)
            {
                string letter = match.Value;

                health += char.Parse(letter);
            }

            return health;
        }

        static double CalculateDamage(MatchCollection damagePoints, Regex regexTwo, Regex regexThree, string name)
        {

            double damage = 0;

            var dmgPoints = regexTwo.Matches(name);

            foreach (Match match in dmgPoints)
            {
                double dmg = double.Parse(match.Value);

                damage += dmg;
            }

            damage = MultiplyOrDivide(damagePoints, regexThree, damage, name);

            return damage;
        }

        static double MultiplyOrDivide(MatchCollection multiplyDivide, Regex regexThree, double damage, string name)
        {
            multiplyDivide = regexThree.Matches(name);

            foreach (Match match in multiplyDivide)
            {
                string sign = match.Value;

                if (sign == "*")
                {
                    damage *= 2;
                }
                else if (sign == "/")
                {
                    damage /= 2;
                }
            }

            return damage;
        }
    }
}
