using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string line = Console.ReadLine().ToLower();
            string[] command = line.Split();
           

            while (line != "end")
            {
                switch (command[0].ToLower())
                {
                    case "add":
                        numbers.Add(int.Parse(command[1]));
                        break;
                    case "remove":
                        numbers.Remove(int.Parse(command[1]));
                        break;
                    case "removeat":
                        numbers.RemoveAt(int.Parse(command[1]));
                        break;
                    case "insert":
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;
                }
                line = Console.ReadLine();
                command = line.Split();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
