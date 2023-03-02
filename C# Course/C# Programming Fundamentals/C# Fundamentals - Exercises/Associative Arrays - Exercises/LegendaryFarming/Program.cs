using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendaryFarm = new Dictionary<string, int>()
            {
                {"fragments", 0 },
                {"motes", 0 },
                {"shards", 0 }
            };
            Dictionary<string, int> junkFarm = new Dictionary<string, int>();


            string winnerItem = string.Empty;
            bool isCrafted = false;

            while (true)
            {
                string[] farm = Console.ReadLine().ToLower().Split();

                for (int i = 0; i < farm.Length; i += 2)
                {
                    int quantity = int.Parse(farm[i]);
                    string resource = farm[i + 1];

                    if (resource != "shards" && resource != "motes" && resource != "fragments")
                    {
                        if (junkFarm.ContainsKey(resource))
                        {
                            junkFarm[resource] += quantity;
                        }
                        else
                        {
                            junkFarm.Add(resource, quantity);
                        }
                    }
                    else
                    {
                        if (legendaryFarm.ContainsKey(resource))
                        {
                            legendaryFarm[resource] += quantity;
                        }
                        else
                        {
                            legendaryFarm.Add(resource, quantity);
                        }

                        if (legendaryFarm[resource] >= 250)
                        {
                            legendaryFarm[resource] -= 250;

                            if (resource == "shards") winnerItem = "Shadowmourne";
                            else if (resource == "motes") winnerItem = "Dragonwrath";
                            else if (resource == "fragments") winnerItem = "Valanyr";
                            isCrafted = true;
                            break;
                        }
                    }
                }
                if (isCrafted) break;
            }

            Console.WriteLine($"{winnerItem} obtained!");

            foreach (var item in legendaryFarm.OrderByDescending(x => x.Value).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in junkFarm.OrderBy(n => n.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
