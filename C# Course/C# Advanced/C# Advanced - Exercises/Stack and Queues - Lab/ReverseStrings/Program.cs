using System;
using System.Collections;
using System.Collections.Generic;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> chrStack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                chrStack.Push(input[i]);
            }

            while (chrStack.Count > 0)
            {
                Console.Write(chrStack.Pop());
            }
        }
    }
}
