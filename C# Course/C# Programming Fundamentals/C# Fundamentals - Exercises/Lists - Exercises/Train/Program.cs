using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> passangers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int capacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string[] command = input.Split();

            while (input != "end")
            {

                if (command[0] == "Add")
                {
                    passangers.Add(int.Parse(command[1]));
                }
                else
                {
                    for (int i = 0; i < passangers.Count; i++)
                    {
                        if (int.Parse(command[0]) + passangers[i] <= capacity)
                        {
                            passangers[i] += int.Parse(command[0]);
                            break;
                        }
                    }
                }

                input = Console.ReadLine();
                command = input.Split();

            }

            Console.WriteLine(string.Join(" ", passangers));
        }
    }
}
