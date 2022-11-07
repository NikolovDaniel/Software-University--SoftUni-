using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().Reverse().ToArray();

            Stack<string> calc = new Stack<string>(input);

            while (calc.Count > 1)
            {
                int numOne = int.Parse(calc.Pop());
                string op = calc.Pop();
                int numTwo = int.Parse(calc.Pop());

                if (op == "-")
                {
                    calc.Push((numOne - numTwo).ToString());
                }
                else if (op == "+")
                {
                    calc.Push((numOne + numTwo).ToString());
                }
            }

            Console.WriteLine(calc.Peek());
        }
    }
}
