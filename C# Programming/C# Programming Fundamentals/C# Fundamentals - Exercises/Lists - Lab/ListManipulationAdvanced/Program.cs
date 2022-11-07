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


            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            bool isChecked = false;


            while (command[0].ToLower() != "end")
            {
                switch (command[0].ToLower())
                {
                    case "add":
                        numbers.Add(int.Parse(command[1]));
                        isChecked = true;
                        break;

                    case "remove":
                        numbers.Remove(int.Parse(command[1]));
                        isChecked = true;
                        break;

                    case "removeat":
                        numbers.RemoveAt(int.Parse(command[1]));
                        isChecked = true;
                        break;

                    case "insert":
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        isChecked = true;
                        break;

                    case "contains":
                        string answer = string.Empty;
                        answer = numbers.Contains(int.Parse(command[1])) ? "Yes" : "No such number";
                        Console.WriteLine(answer);
                        break;

                    case "printeven":
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 == 0)));
                        break;

                    case "printodd":
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 != 0)));
                        break;

                    case "getsum":
                        Console.WriteLine(numbers.Sum());
                        break;

                    case "filter":

                        if (command[1] == "<")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(n => n < int.Parse(command[2]))));
                        }

                        else if (command[1] == ">")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(n => n > int.Parse(command[2]))));
                        }
                        else if (command[1] == "<=")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(n => n <= int.Parse(command[2]))));
                        }
                        else if (command[1] == ">=")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(n => n >= int.Parse(command[2]))));
                        }

                        break;
                }

                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            if (isChecked) Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
