using System;
using System.Collections.Generic;
using System.Linq;

namespace StackAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> numbers = new Stack<int>(arr);

            string input = Console.ReadLine().ToLower();

            while (input != "end")
            {
                string[] commands = input.Split();
                string cmd = commands[0];

                if (cmd == "add")
                {
                    int numOne = int.Parse(commands[1]);
                    int numTwo = int.Parse(commands[2]);

                    numbers.Push(numOne);
                    numbers.Push(numTwo);
                }
                else if (cmd == "remove")
                {
                    int num = int.Parse(commands[1]);

                    if (num > 0 && num <= numbers.Count)
                    {
                        for (int i = 0; i < num; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }

                input = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
