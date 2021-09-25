using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredictParty
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            string input = Console.ReadLine();

            while (input != "Party!")
            {

                string[] tokens = input.Split();

                Predicate<string> predicate = GetPredicate(tokens[1], tokens[2]);

                switch (tokens[0])
                {
                    case "Remove":
                        names.RemoveAll(predicate);
                        break;
                    case "Double":
                        {
                            List<string> matches = names.FindAll(predicate);

                            if (matches.Count > 0)
                            {
                                int index = names.FindIndex(predicate);
                                names.InsertRange(index, matches);
                            }

                            break;
                        }
                }

                input = Console.ReadLine();
            }

            if (names.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string command, string text)
        {
            if (command == "StartsWith")
            {
                return name => name.StartsWith(text);
            }
            else if (command == "EndsWith")
            {
                return name => name.EndsWith(text);
            }
            else if (command == "Length")
            {
                return name => name.Length == int.Parse(text);
            }
            else
            {
                throw new ArgumentException("Invalid command type: " + command);
            }
        }
    }
}