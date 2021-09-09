using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanetDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string input = string.Empty;

            Dictionary<string, List<double>> plants = new Dictionary<string, List<double>>();
            Dictionary<string, int> plantsRating = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();

                string[] commands = input.Split("<->", StringSplitOptions.RemoveEmptyEntries);

                string plant = commands[0];
                int rarity = int.Parse(commands[1]);

                if (plantsRating.ContainsKey(plant))
                {
                    plantsRating[plant] = rarity;
                }
                else
                {
                    plantsRating.Add(plant, rarity);
                }

                if (!plants.ContainsKey(plant))
                {
                    plants.Add(plant, new List<double>());
                }

            }

            input = Console.ReadLine();

            while (input != "Exhibition")
            {

                string[] commands = input.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

                string cmd = commands[0];

                if (cmd == "Rate:")
                {
                    string plant = commands[1];
                    double rating = double.Parse(commands[2]);

                    if (plants.ContainsKey(plant))
                    {
                        plants[plant].Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (cmd == "Update:")
                {
                    string plant = commands[1];
                    int rarity = int.Parse(commands[2]);

                    if (plantsRating.ContainsKey(plant))
                    {
                        plantsRating[plant] = rarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (cmd == "Reset:")
                {
                    string plant = commands[1];

                    if (plants.ContainsKey(plant))
                    {
                        plants[plant].Clear();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }

                input = Console.ReadLine();
            }

            foreach (var plant in plants)
            {
                double average = 0;

                if (plant.Value.Count > 0)
                {
                    for (int i = 0; i < plant.Value.Count; i++)
                    {
                        average = plant.Value.Sum() / plant.Value.Count;
                    }
                }

                plants[plant.Key].Clear();
                plants[plant.Key].Add(average);

            }

            Dictionary<string, List<double>> result = new Dictionary<string, List<double>>();

            foreach (var item in plants)
            {

                result.Add(item.Key, new List<double>() { plantsRating[item.Key], item.Value[0] });

            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var item in result.OrderByDescending(x => x.Value[0]).ThenByDescending(x => x.Value[1])) 
            {
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value[0]}; Rating: {item.Value[1]:f2}");
            }
        }
    }
}
