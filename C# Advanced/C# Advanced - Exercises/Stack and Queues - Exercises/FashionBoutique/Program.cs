using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> racks = new Stack<int>(clothes.Reverse());

            int capacity = int.Parse(Console.ReadLine());
            int capacityVariable = capacity;

            int racksCount = 0;

            while (racks.Count > 0)
            {
                if (capacityVariable - racks.Peek() < 0)
                {
                    racksCount++;
                    capacityVariable = capacity;
                }
                else if (capacityVariable - racks.Peek() == 0)
                {
                    racksCount++;
                    capacityVariable -= racks.Pop();
                    capacityVariable = capacity;
                }
                else
                {
                    capacityVariable -= racks.Pop();
                    if (racks.Count == 0)
                    {
                        racksCount++;
                        break;
                    }
                }
            }

            Console.WriteLine(racksCount);

        }
    }
}
