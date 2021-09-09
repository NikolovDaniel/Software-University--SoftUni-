using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeandLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> players = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                string[] player = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int hp = int.Parse(player[1]);
                int mp = int.Parse(player[2]);

                if (hp <= 100 && mp <= 200)
                {
                    players.Add(player[0], new List<int>() { hp, mp});

                }

            }

            string input = Console.ReadLine();

            while (input != "End")
            {

                string[] commands = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string cmdOne = commands[0];

                if (cmdOne == "CastSpell")
                {
                    string heroName = commands[1];
                    int mpNeeded = int.Parse(commands[2]);
                    string spellName = commands[3];

                    int currentMP = players[heroName][1];

                    if (currentMP>= mpNeeded)
                    {
                        players[heroName][1] -= mpNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {players[heroName][1]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (cmdOne == "TakeDamage")
                {
                    string heroName = commands[1];
                    int damage = int.Parse(commands[2]);
                    string attacker = commands[3];

                    int currentHP = players[heroName][0];

                    if ((currentHP -= damage) > 0)
                    {
                        players[heroName][0] -= damage;
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {players[heroName][0]} HP left!");
                    }
                    else if ((players[heroName][0] -= damage) <= 0)
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        players.Remove(heroName);
                    }
                }
                else if (cmdOne == "Recharge")
                {
                    string heroName = commands[1];
                    int mpAmount = int.Parse(commands[2]);

                    int currentMP = players[heroName][1];

                    if ((currentMP += mpAmount) > 200)
                    {
                        Console.WriteLine($"{heroName} recharged for {200 - players[heroName][1]} MP!");
                        players[heroName][1] = 200;
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} recharged for {mpAmount} MP!");
                        players[heroName][1] += mpAmount;
                    }
                }
                else if (cmdOne == "Heal")
                {
                    string heroName = commands[1];
                    int hpAmount = int.Parse(commands[2]);

                    int currentHP = players[heroName][0];

                    if ((currentHP += hpAmount) > 100)
                    {
                        Console.WriteLine($"{heroName} healed for {100 - players[heroName][0]} HP!");
                        players[heroName][0] = 100;
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} healed for {hpAmount} HP!");
                        players[heroName][0] += hpAmount;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var item in players.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                Console.WriteLine($"  HP: {item.Value[0]}");
                Console.WriteLine($"  MP: {item.Value[1]}");
            }

        }
    }
}
