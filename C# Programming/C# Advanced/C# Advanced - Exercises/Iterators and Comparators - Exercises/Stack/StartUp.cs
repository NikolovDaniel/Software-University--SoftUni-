using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);

                    }
                }
                else if (tokens[0] == "Push")
                {
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        stack.Push(int.Parse(tokens[i]));
                    }
                }

                input = Console.ReadLine();
            }
            
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
