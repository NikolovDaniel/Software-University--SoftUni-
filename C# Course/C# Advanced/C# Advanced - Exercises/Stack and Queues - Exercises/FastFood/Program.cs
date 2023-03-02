using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());

            int[] arrayOrders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(arrayOrders);

            Console.WriteLine(orders.Max());

            while (orders.Count > 0)
            {
                if (quantityFood - orders.Peek() < 0)
                {
                    break;
                }
                else
                {
                    quantityFood -= orders.Dequeue();
                }
            }

            if (orders.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
