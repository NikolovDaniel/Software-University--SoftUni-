using System;
using System.Linq;

namespace WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input = Console.ReadLine();


            while (input != "Travel")
            {

                string[] commands = input.Split(":", StringSplitOptions.RemoveEmptyEntries);

                string cmdOne = commands[0];

                if (cmdOne == "Add Stop")
                {
                    int index = int.Parse(commands[1]);
                    string message = commands[2];

                    if (index >= 0 && index <= text.Length - 1)
                    {
                        text = text.Insert(index, message);
                    }
                    Console.WriteLine(text);
                }
                else if (cmdOne == "Remove Stop")
                {
                    int startIndex = Math.Min(int.Parse(commands[1]), int.Parse(commands[2]));
                    int endIndex = Math.Max(int.Parse(commands[1]), int.Parse(commands[2]));

                    if (startIndex >= 0 && endIndex <= text.Length -1)
                    {
                        for (int i = endIndex; i >= startIndex; i--)
                        {
                            text = text.Remove(i, 1);
                        }
                    }
                    Console.WriteLine(text);

                }
                else if (cmdOne == "Switch")
                {
                    string oldString = commands[1];
                    string newString = commands[2];

                    if (text.Contains(oldString))
                    {
                        text = text.Replace(oldString, newString);
                    }
                    Console.WriteLine(text);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {text}");
        }
    }
}
