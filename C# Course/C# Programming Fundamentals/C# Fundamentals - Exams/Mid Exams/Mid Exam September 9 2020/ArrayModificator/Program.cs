using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayModificator
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
            string[] cmd = input.Split();

            while (input != "end")
            {

                string command = cmd[0];

                if (command == "swap")
                {
                    int indexOne = Math.Min(int.Parse(cmd[1]), int.Parse(cmd[2]));
                    int indexTwo = Math.Max(int.Parse(cmd[1]), int.Parse(cmd[2]));

                    int num = numbers[indexTwo]; // num = 5;
                    numbers.RemoveAt(indexTwo); // Remove 5
                    numbers.Insert(indexTwo, numbers[indexOne]); // Add 3
                    numbers.RemoveAt(indexOne); // Remove 3
                    numbers.Insert(indexOne, num); // Add 5

                }

                else if (command == "multiply")
                {
                    int indexOne = int.Parse(cmd[1]);
                    int indexTwo = int.Parse(cmd[2]);

                    int result = numbers[indexOne] * numbers[indexTwo];
                    numbers[indexOne] = result;
                }

                else if (command == "decrease")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] -= 1;
                    }
                }

                input = Console.ReadLine();
                cmd = input.Split();
            }

            Console.WriteLine(string.Join(", ", numbers));

        }
    }
}
