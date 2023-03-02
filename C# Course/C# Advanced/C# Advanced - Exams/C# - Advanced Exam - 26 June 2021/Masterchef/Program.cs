using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ingredientsValues = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray(); 
            int[] freshnessValues = Console.ReadLine().Split()
                 .Select(int.Parse)
                 .ToArray();

            Dictionary<string, int> result = new Dictionary<string, int>();

            Queue<int> ingredients = new Queue<int>(ingredientsValues);
            Stack<int> freshness = new Stack<int>(freshnessValues);

            while (ingredients.Count > 0 || freshness.Count > 0)
            {
               
                if (ingredients.Count > 0 && freshness.Count > 0)
                {
                    if (ingredients.Peek() == 0)
                    {
                        ingredients.Dequeue();
                        continue;
                    }

                    if (ingredients.Peek() * freshness.Peek() == 150)
                    {
                        if (result.ContainsKey("Dipping sauce"))
                        {
                            result["Dipping sauce"]++;
                        }
                        else
                        {
                            result.Add("Dipping sauce", 1);
                        }
                        ingredients.Dequeue();
                        freshness.Pop();
                    }
                    else if (ingredients.Peek() * freshness.Peek() == 250)
                    {
                        if (result.ContainsKey("Green salad"))
                        {
                            result["Green salad"]++;
                        }
                        else
                        {
                            result.Add("Green salad", 1);
                        }
                        ingredients.Dequeue();
                        freshness.Pop();
                    }
                    else if (ingredients.Peek() * freshness.Peek() == 300)
                    {
                        if (result.ContainsKey("Chocolate cake"))
                        {
                            result["Chocolate cake"]++;
                        }
                        else
                        {
                            result.Add("Chocolate cake", 1);
                        }
                        ingredients.Dequeue();
                        freshness.Pop();
                    }
                    else if (ingredients.Peek() * freshness.Peek() == 400)
                    {
                        if (result.ContainsKey("Lobster"))
                        {
                            result["Lobster"]++;
                        }
                        else
                        {
                            result.Add("Lobster", 1);
                        }
                        ingredients.Dequeue();
                        freshness.Pop();
                    }
                    else
                    {
                        if (freshness.Count > 0 && ingredients.Count > 0)
                        {
                            freshness.Pop();
                            ingredients.Enqueue(ingredients.Dequeue() + 5);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            if (result.Count == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");

                if (ingredients.Any())
                {
                    Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
                }
                foreach (var item in result.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"# {item.Key} --> {item.Value}");
                }
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");

                if (ingredients.Any())
                {
                    Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
                }
                foreach (var item in result.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"# {item.Key} --> {item.Value}");
                }
            }
        }
    }
}
