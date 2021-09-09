using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();
            string[] command = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);

            while (input != "end")
            {

                if (command[0] == "Delete")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] == int.Parse(command[1]))
                        {
                            numbers.Remove(numbers[i]);
                        }
                    }
                }

                else if (command[0] == "Insert")
                {
                   
                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));                 
                }

                input = Console.ReadLine();
                command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
