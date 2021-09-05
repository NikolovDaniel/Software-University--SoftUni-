using System;
using System.Collections.Generic;
using System.Linq;

namespace TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> loot = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> stolenLoot = new List<string>();

            string input = Console.ReadLine();
            string[] command = input.Split();


            while (input != "Yohoho!")
            {

                string commOne = command[0];

                if (commOne == "Loot")
                {
                    List<string> lootedItems = command.ToList();
                    lootedItems.Remove("Loot");
                    bool isThere = true;

                    foreach (var item in lootedItems)
                    {
                        foreach (var element in loot)
                        {
                            if (item == element) isThere = false;
                        }

                        if (isThere)
                        {
                            loot.Insert(0, item);
                        }
                        isThere = true;
                    }
                }

                else if (commOne == "Drop")
                {
                    int index = int.Parse(command[1]);
                    bool isValid = index >= 0 && index <= loot.Count - 1;

                    if (isValid)
                    {
                        string currentLoot = loot[index];
                        loot.RemoveAt(index);
                        loot.Add(currentLoot);
                    }
                }

                else if (commOne == "Steal")
                {
                    int count = int.Parse(command[1]);

                    if (count > loot.Count - 1)
                    {
                        for (int i = 0; i < loot.Count; i++)
                        {
                            stolenLoot.Add(loot[i]);
                        }
                    }
                    else if (count >= 0 && count <= loot.Count - 1)
                    {
                        for (int i = loot.Count - count; i <= loot.Count - 1 ; i++)
                        {
                            stolenLoot.Add(loot[i]);                           
                        }                      
                    }
                    Console.WriteLine(string.Join(", ", stolenLoot));

                    foreach (var item in stolenLoot)
                    {
                        foreach (var element in loot)
                        {
                            if (item == element)
                            {
                                loot.Remove(element);
                                break;
                            }
                        }
                    }
                }
                stolenLoot.Clear();
                input = Console.ReadLine();
                command = input.Split();
            }

            double totalSum = 0;

            foreach (var item in loot)
            {
                totalSum += item.Length;
            }

            totalSum /= loot.Count;

            if (loot.Count == 0) Console.WriteLine("Failed treasure hunt.");
            else Console.WriteLine($"Average treasure gain: {totalSum:f2} pirate credits.");

        }
    }
}
