using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string input = string.Empty;

            Dictionary<string, List<string>> pieces = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();

                string[] commands = input.Split("|", StringSplitOptions.RemoveEmptyEntries);

                string piece = commands[0];
                string composer = commands[1];
                string key = commands[2];

                if (!pieces.ContainsKey(piece))
                {
                    pieces.Add(piece, new List<string>() { composer, key });
                }

            }

            input = Console.ReadLine();

            while (input != "Stop")
            {

                string[] commands = input.Split("|", StringSplitOptions.RemoveEmptyEntries);

                string cmdOne = commands[0];
                
                if (cmdOne == "Add")
                {
                    string piece = commands[1];
                    string composer = commands[2];
                    string key = commands[3];

                    if (!pieces.ContainsKey(piece))
                    {
                        pieces.Add(piece, new List<string>() { composer, key });
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }


                }
                else if (cmdOne == "Remove")
                {
                    string piece = commands[1];

                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (cmdOne == "ChangeKey")
                {
                    string piece = commands[1];
                    string key = commands[2];

                    if (pieces.ContainsKey(piece))
                    {
                        pieces[piece][1] = key;
                        Console.WriteLine($"Changed the key of {piece} to {key}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var item in pieces.OrderBy(x => x.Key).ThenBy(x => x.Value[0]))
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value[0]}, Key: {item.Value[1]}");
            }
        }
    }
}
