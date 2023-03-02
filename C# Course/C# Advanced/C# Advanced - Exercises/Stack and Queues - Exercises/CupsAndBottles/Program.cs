using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();

            int[] bottles = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> cups = new Queue<int>(cupsCapacity);
            Stack<int> filledBottles = new Stack<int>(bottles);

            int wastedWater = 0;

            while (cups.Count > 0 && filledBottles.Count > 0)
            {
                int currCup = cups.Peek();
                int currBottle = filledBottles.Peek();

                while (currCup > 0 && cups.Count > 0)
                {
                    if (currCup - currBottle > 0)
                    {
                        currCup -= currBottle;
                        filledBottles.Pop();
                        currBottle = filledBottles.Peek();
                    }
                    else if (currCup - currBottle <= 0)
                    {
                        wastedWater += currBottle - currCup;
                        filledBottles.Pop();
                        cups.Dequeue();

                        if (filledBottles.Count > 0)
                        {
                            currBottle = filledBottles.Peek();
                        }
                        else
                        {
                            break;
                        }

                        if (cups.Count > 0)
                        {
                            currCup = cups.Peek();
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            if (cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else if (filledBottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", filledBottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
