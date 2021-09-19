using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] clothing = Console.ReadLine()
                    .Split(new string[] { ",", " -> " }, StringSplitOptions.RemoveEmptyEntries);

                string color = clothing[0];

                if (wardrobe.ContainsKey(color))
                {
                    for (int j = 1; j < clothing.Length; j++)
                    {
                        if (wardrobe[color].ContainsKey(clothing[j]))
                        {
                            wardrobe[color][clothing[j]]++;
                        }
                        else
                        {
                            wardrobe[color].Add(clothing[j], 1);
                        }
                    }
                }
                else
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                    for (int j = 1; j < clothing.Length; j++)
                    {
                        if (wardrobe[color].ContainsKey(clothing[j]))
                        {
                            wardrobe[color][clothing[j]]++;
                        }
                        else
                        {
                            wardrobe[color].Add(clothing[j], 1);
                        }
                    }
                }

            }

            string[] clothes = Console.ReadLine().Split();

            string colorDress = clothes[0];
            string item = clothes[1];

            foreach (var colors in wardrobe)
            {
                Console.WriteLine($"{colors.Key} clothes:");

                foreach (var itm in colors.Value)
                {
                    if (colorDress == colors.Key && itm.Key == item)
                    {
                        Console.WriteLine($"* {itm.Key} - {itm.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {itm.Key} - {itm.Value}");
                    }
                }
            }

        }
    }
}
