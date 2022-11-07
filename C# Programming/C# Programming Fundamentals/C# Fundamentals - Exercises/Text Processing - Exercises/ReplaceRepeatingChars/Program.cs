using System;
using System.Collections.Generic;
using System.Linq;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = Console.ReadLine();

            while (input != "Craft!")
            {

                string[] commands = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string cmdOne = commands[0];

                if (cmdOne == "Collect")
                {
                    string item = commands[1];

                    if (!items.Contains(item))
                    {
                        items.Add(item);
                    }
                }
                else if (cmdOne == "Drop")
                {
                    string item = commands[1];

                    if (items.Contains(item))
                    {
                        items.Remove(item);
                    }

                }
                else if (cmdOne == "Combine Items")
                {
                    string[] oldNewItems = commands[1].Split(":");
                    string oldItem = oldNewItems[0];
                    string newItem = oldNewItems[1];

                    if (items.Contains(oldItem))
                    {
                        int index = items.IndexOf(oldItem);
                        items.Insert(index + 1, newItem);
                    }

                }
                else if (cmdOne == "Renew")
                {
                    string item = commands[1];

                    if (items.Contains(item))
                    {
                        items.Remove(item);
                        items.Add(item);
                    }

                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", items));



        }
    }
}
