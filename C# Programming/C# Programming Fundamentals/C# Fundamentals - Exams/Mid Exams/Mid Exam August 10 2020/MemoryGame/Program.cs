using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> sequenceElements = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            string input = Console.ReadLine();
            string[] cmd = input.Split();

            int moves = 0;

            while (input != "end")
            {
                moves++;
                int indexOne = Math.Min(int.Parse(cmd[0]), int.Parse(cmd[1]));
                int indexTwo = Math.Max(int.Parse(cmd[0]), int.Parse(cmd[1]));

                bool isValid = indexOne >= 0 && indexOne < sequenceElements.Count - 1 && indexTwo > 0 && indexTwo <= sequenceElements.Count - 1;
                bool isSame = indexOne != indexTwo;

                if (isValid && isSame)
                {
                    if (sequenceElements[indexOne] == sequenceElements[indexTwo])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {sequenceElements[indexOne]}!");
                        sequenceElements.RemoveAt(indexTwo);
                        sequenceElements.RemoveAt(indexOne); 
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }
                }
                else
                {
                    int middle = sequenceElements.Count / 2;
                    sequenceElements.Insert(middle, "-" + moves.ToString() + "a");
                    sequenceElements.Insert(middle + 1, "-" + moves.ToString() + "a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }

                if (sequenceElements.Count == 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    return;
                }


                input = Console.ReadLine();
                cmd = input.Split();
            }

            Console.WriteLine($"Sorry you lose :(");
            Console.WriteLine(string.Join(" ", sequenceElements));


        }
    }
}
