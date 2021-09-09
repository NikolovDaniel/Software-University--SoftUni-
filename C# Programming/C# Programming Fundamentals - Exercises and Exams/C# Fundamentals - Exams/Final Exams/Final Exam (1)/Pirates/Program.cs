using System;
using System.Collections.Generic;
using System.Linq;

namespace Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<int>> pirateTowns = new Dictionary<string, List<int>>();


            while (input != "Sail")
            {

                string[] commands = input.Split("||", StringSplitOptions.RemoveEmptyEntries);

                string town = commands[0];
                int population = int.Parse(commands[1]);
                int gold = int.Parse(commands[2]);

                if (pirateTowns.ContainsKey(town))
                {
                    pirateTowns[town][0] += population;
                    pirateTowns[town][1] += gold;
                }
                else
                {
                    pirateTowns.Add(town, new List<int>() { population, gold });
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {

                string[] commands = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string cmd = commands[0];

                if (cmd == "Plunder")
                {
                    string town = commands[1];
                    int population = int.Parse(commands[2]);
                    int gold = int.Parse(commands[3]);

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {population} citizens killed.");

                    if (pirateTowns[town][0] - population <= 0 || pirateTowns[town][1] - gold <= 0)
                    {
                        Console.WriteLine($"{town} has been wiped off the map!");
                        pirateTowns.Remove(town);
                    }
                    else
                    {
                        pirateTowns[town][0] -= population;
                        pirateTowns[town][1] -= gold;
                    }

                }
                else if (cmd == "Prosper")
                {
                    string town = commands[1];
                    int gold = int.Parse(commands[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        pirateTowns[town][1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {pirateTowns[town][1]} gold.");
                    }

                }

                input = Console.ReadLine();
            }

            if (pirateTowns.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {pirateTowns.Count} wealthy settlements to go to:");

                foreach (var item in pirateTowns.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{item.Key} -> Population: {item.Value[0]} citizens, Gold: {item.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }

            
        }
    }
}
