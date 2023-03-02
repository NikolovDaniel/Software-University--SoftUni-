using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLootBox = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondLootBox = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> lootBoxOne = new Queue<int>(firstLootBox);
            Stack<int> lootBoxTwo = new Stack<int>(secondLootBox);

            List<int> values = new List<int>();

            while (true)
            {
                if (lootBoxOne.Count > 0 && lootBoxTwo.Count > 0)
                {
                    if ((lootBoxOne.Peek() + lootBoxTwo.Peek()) % 2 == 0)
                    {
                        values.Add(lootBoxOne.Dequeue() + lootBoxTwo.Pop());
                    }
                    else
                    {
                        lootBoxOne.Enqueue(lootBoxTwo.Pop());
                    }
                }
                else
                {
                    break;
                }
            }

            if (lootBoxOne.Count > 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            else
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (values.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {values.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {values.Sum()}");
            }
        }
    }
}
