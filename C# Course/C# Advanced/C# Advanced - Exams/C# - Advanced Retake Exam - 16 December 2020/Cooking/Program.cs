using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquidsArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] ingredientsArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToArray();

            Queue<int> liquids = new Queue<int>(liquidsArr);
            Stack<int> ingredients = new Stack<int>(ingredientsArr);

            Dictionary<string, int> result = new Dictionary<string, int>()
            {
                {"Bread", 0 },
                {"Cake", 0 },
                {"Pastry", 0 },
                {"Fruit Pie", 0 }
            };

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                string currItem = string.Empty;

                if (liquids.Peek() + ingredients.Peek() == 25)
                {
                    currItem = "Bread"; 
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (liquids.Peek() + ingredients.Peek() == 50)
                {
                    currItem = "Cake";
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (liquids.Peek() + ingredients.Peek() == 75)
                {
                    currItem = "Pastry";
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (liquids.Peek() + ingredients.Peek() == 100)
                {
                    currItem = "Fruit Pie";
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Push(ingredients.Pop() + 3);
                }

                if (result.ContainsKey(currItem))
                {
                    result[currItem]++;
                }
            }

            int allFoodCount = result.Where(x => x.Value >= 1).ToList().Count;

            if (allFoodCount < 4)
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.".TrimEnd());
            }
            else if (allFoodCount >= 4)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!".TrimEnd());
            }

            PrintLiquids(liquids);
            PrintIngredients(ingredients);
            PrintDictionary(result);
        }

        private static void PrintDictionary(Dictionary<string, int> result)
        {
            foreach (var item in result.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private static void PrintIngredients(Stack<int> ingredients)
        {
            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
        }

        private static void PrintLiquids(Queue<int> liquids)
        {
            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
        }
    }
}
