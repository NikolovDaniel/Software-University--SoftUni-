using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] names = Console.ReadLine().Split();

            int rounds = int.Parse(Console.ReadLine());

            Queue<string> players = new Queue<string>(names);

            while (players.Count > 1)
            {

                for (int i = 1; i < rounds; i++)
                {
                    players.Enqueue(players.Dequeue());
                }

                Console.WriteLine($"Removed {players.Dequeue()}");

            }

            Console.WriteLine($"Last is {players.Peek()}");

        }
    }
}
