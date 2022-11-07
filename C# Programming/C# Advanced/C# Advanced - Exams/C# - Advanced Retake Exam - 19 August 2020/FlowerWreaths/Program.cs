using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lilliesArr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] rosesArr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> lillies = new Stack<int>(lilliesArr);
            Queue<int> roses = new Queue<int>(rosesArr);

            List<int> storedFlowers = new List<int>();

            int wreaths = 0;

            while (lillies.Count > 0 && roses.Count > 0)
            {
                if (lillies.Peek() + roses.Peek() == 15)
                {
                    wreaths++;
                    lillies.Pop();
                    roses.Dequeue();
                }
                else if (lillies.Peek() + roses.Peek() > 15)
                {
                    lillies.Push(lillies.Pop() - 2);
                }
                else
                {
                    storedFlowers.Add(lillies.Pop() + roses.Dequeue());
                }
            }

            if (storedFlowers.Any())
            {
                int addWreaths = storedFlowers.Sum() / 15;
                wreaths += addWreaths;
            }

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
