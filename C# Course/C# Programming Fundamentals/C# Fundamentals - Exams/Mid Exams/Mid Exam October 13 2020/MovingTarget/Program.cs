using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "End")
            {

                string[] commands = input.Split();

                string cmdOne = commands[0];

                if (cmdOne == "Shoot")
                {
                    int index = int.Parse(commands[1]);
                    int power = int.Parse(commands[2]);

                    if (index >= 0 && index <= sequence.Count - 1)
                    {
                        if (sequence[index] - power > 0)
                        {
                            sequence[index] -= power;
                        }
                        else
                        {
                            sequence.RemoveAt(index);
                        }
                    }

                }
                else if (cmdOne == "Add")
                {
                    int index = int.Parse(commands[1]);
                    int value = int.Parse(commands[2]);

                    if (index >= 0 && index <= sequence.Count - 1)
                    {
                        sequence.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (cmdOne == "Strike")
                {
                    int index = int.Parse(commands[1]);
                    int radius = int.Parse(commands[2]);

                    if (index - radius < 0 || index + radius > sequence.Count - 1)
                    {
                        Console.WriteLine("Strike missed!");
                    }
                    else
                    {
                        for (int i = 1; i <= radius; i++)
                        {
                            sequence.RemoveAt(index - 1);
                            sequence.RemoveAt(index);
                            index--;
                        }
                        sequence.RemoveAt(index);
                    }
                }

                input = Console.ReadLine();

            }

            Console.WriteLine(string.Join("|", sequence));

        }
    }
}
