using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Reveal")
            {
                string[] commands = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries);

                string cmdOne = commands[0];

                if (cmdOne == "InsertSpace")
                {
                    int index = int.Parse(commands[1]);

                    text = text.Insert(index, " ");

                    Console.WriteLine(text);
                }
                else if (cmdOne == "Reverse")
                {
                    string substring = commands[1];

                    if (text.Contains(substring))
                    {
                        text = text.Remove(text.IndexOf(substring), substring.Length);
                        string newSubstring = string.Empty;

                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            newSubstring += substring[i].ToString();
                        }

                        text = text.Insert(text.Length, newSubstring);

                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (cmdOne == "ChangeAll")
                {
                    string substring = commands[1];
                    string replacement = commands[2];

                    if (text.Contains(substring))
                    {
                        text = text.Replace(substring, replacement);
                        Console.WriteLine(text);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {text}");
        }
    }
}
