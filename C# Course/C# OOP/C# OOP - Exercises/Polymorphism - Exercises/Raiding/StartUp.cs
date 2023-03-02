using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<BaseHero> heroes = new List<BaseHero>();

            while (heroes.Count != n)
            {
                string name = Console.ReadLine();
                string race = Console.ReadLine();

                if (race == "Druid")
                {
                    Druid druid = new Druid(name, race);
                    heroes.Add(druid);
                }
                else if (race == "Paladin")
                {
                    Paladin paladin = new Paladin(name, race);
                    heroes.Add(paladin);
                }
                else if (race == "Rogue")
                {
                    Rogue rogue = new Rogue(name, race);
                    heroes.Add(rogue);
                }
                else if (race == "Warrior")
                {
                    Warrior warrior = new Warrior(name, race);
                    heroes.Add(warrior);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }

            }

            int power = int.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                power -= hero.Power;
                Console.WriteLine(hero.CastAbility());
                if (power <= 0)
                {
                    Console.WriteLine("Victory!");
                    return;
                }
            }

            Console.WriteLine("Defeat...");
        }
    }
}
