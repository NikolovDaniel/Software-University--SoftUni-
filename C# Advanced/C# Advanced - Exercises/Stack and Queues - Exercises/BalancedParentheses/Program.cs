using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> parentheses = new Stack<char>();

            foreach (var symbol in input)
            {

                if (parentheses.Any())
                {

                    char checker = parentheses.Peek();

                    if (checker == '(' && symbol == ')')
                    {
                        parentheses.Pop();
                        continue;
                    }
                    else if (checker == '[' && symbol == ']')
                    {
                        parentheses.Pop();
                        continue;
                    }
                    else if (checker == '{' && symbol == '}')
                    {
                        parentheses.Pop();
                        continue;
                    }
                }

                parentheses.Push(symbol);
            }

            if (parentheses.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
