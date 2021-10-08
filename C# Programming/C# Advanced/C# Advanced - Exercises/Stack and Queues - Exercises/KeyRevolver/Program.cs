using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            int priceBullet = int.Parse(Console.ReadLine());
            int sizeBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] locks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int intelligence = int.Parse(Console.ReadLine());

            Stack<int> bulletStack = new Stack<int>(bullets);
            Queue<int> lockStack = new Queue<int>(locks);

            int count = 0;
            int reload = 0;

            while (bulletStack.Count > 0 && lockStack.Count > 0)
            {
                int bulletSize = bulletStack.Pop();
                reload++;
                count++;

                if (bulletSize <= lockStack.Peek())
                {
                    Console.WriteLine("Bang!");
                    lockStack.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (reload == sizeBarrel && bulletStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    reload = 0;
                    continue;
                }
            }

            if (lockStack.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {lockStack.Count}");
            }
            else
            {
                double totalSum = intelligence - (count * priceBullet);

                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${totalSum}");
            }
        }
    }
}
