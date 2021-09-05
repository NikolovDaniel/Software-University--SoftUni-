using System;
using System.Text;

namespace PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder(text);


            while (input != "Done")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdOne = commands[0];

                if (cmdOne == "TakeOdd")
                {
                    StringBuilder currentSb = sb;
                    sb = new StringBuilder();
                    for (int i = 0; i < currentSb.Length; i++)
                    {
                        if (i % 2 == 1)
                        {
                            sb.Append(currentSb[i]);
                        }
                    }

                    Console.WriteLine(sb);
                }
                else if (cmdOne == "Cut")
                {
                    int index = int.Parse(commands[1]);
                    int length = int.Parse(commands[2]);

                    sb.Remove(index, length);

                    Console.WriteLine(sb);
                }
                else if (cmdOne == "Substitute")
                {
                    string substring = commands[1];
                    string substitute = commands[2];

                    if (sb.ToString().Contains(substring))
                    {
                        sb.Replace(substring, substitute);
                        Console.WriteLine(sb);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {sb}");
        }
    }
}
