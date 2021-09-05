using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string output = "";

            for (int i = input.Length - 1; i >= 0; i--)
            {
                char pasteLetter = input[i];
                output += pasteLetter.ToString();
            }

            Console.WriteLine(output);
        }
    }
}
