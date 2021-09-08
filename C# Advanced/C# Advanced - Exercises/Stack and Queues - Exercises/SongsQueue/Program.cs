using System;
using System.Collections.Generic;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> songs = new Queue<string>(input);

            string command = Console.ReadLine();


            while (songs.Count > 0)
            {
                if (command.Contains("Play"))
                {
                    songs.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    int indexOne = command.IndexOf("Add");
                    command = command.Remove(indexOne, 4);

                    if (songs.Contains(command))
                    {
                        Console.WriteLine($"{command} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(command);
                    }
                }
                else if (command.Contains("Show"))
                {
                    Console.WriteLine($"{string.Join(", ", songs)}");
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");

        }
    }
}
