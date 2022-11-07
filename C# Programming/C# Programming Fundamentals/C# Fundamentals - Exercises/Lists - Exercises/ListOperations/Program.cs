using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
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
            string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input != "End")
            {

                switch (command[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(command[1]));
                        break;

                    case "Insert":
                        if (int.Parse(command[2]) > numbers.Count || int.Parse(command[2]) < 0) Console.WriteLine("Invalid index");
                        else numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;

                    case "Remove":
                        if (int.Parse(command[1]) > numbers.Count || int.Parse(command[1]) < 0) Console.WriteLine("Invalid index");
                        else numbers.RemoveAt(int.Parse(command[1]));
                        break;

                    case "Shift":
                        switch (command[1])
                        {
                            case "left":
                                for (int i = 0; i < int.Parse(command[2]); i++)
                                {
                                    int firstNum = numbers[0];
                                    numbers.Add(firstNum);
                                    numbers.RemoveAt(0);
                                }
                                break;

                            case "right":
                                for (int i = 0; i < int.Parse(command[2]); i++)
                                {
                                    int lastNum = numbers[numbers.Count - 1];
                                    numbers.Insert(0, lastNum);
                                    numbers.RemoveAt(numbers.Count - 1);
                                }
                                break;
                        }
                        break;
                }

                input = Console.ReadLine();
                command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            }

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
