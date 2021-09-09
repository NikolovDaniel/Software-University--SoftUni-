using System;
using System.Text;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder sb = new StringBuilder(text);

            string input = Console.ReadLine();


            while (input != "Generate")
            {
                string[] commands = input.Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                string cmdOne = commands[0];

                if (cmdOne == "Contains")
                {
                    string substring = commands[1];

                    if (sb.ToString().Contains(substring))
                    {
                        Console.WriteLine($"{sb.ToString()} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }

                }
                else if (cmdOne == "Flip")
                {
                    string upperOrLower = commands[1];
                    int startIndex = int.Parse(commands[2]);
                    int endIndex = int.Parse(commands[3]);

                    if (upperOrLower == "Lower")
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            sb[i] = Char.ToLower(sb[i]);
                        }
                    }
                    else if (upperOrLower == "Upper")
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            sb[i] = Char.ToUpper(sb[i]);
                        }
                    }

                    Console.WriteLine(sb.ToString());

                }
                else if (cmdOne == "Slice")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    sb.Remove(startIndex, endIndex - startIndex);

                    Console.WriteLine(sb.ToString());
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {sb.ToString()}");

        }
    }
}
