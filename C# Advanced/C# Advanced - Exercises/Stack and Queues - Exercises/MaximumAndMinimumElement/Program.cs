using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                if (tokens[0] == "1")
                {
                    int num = int.Parse(tokens[1]);

                    numbers.Push(num);
                }
                else if (tokens[0] == "2" && numbers.Count > 0)
                {
                    numbers.Pop();
                }
                else if (tokens[0] == "3" && numbers.Count > 0)
                {
                    Console.WriteLine(numbers.Max());
                }
                else if (tokens[0] == "4" && numbers.Count > 0)
                {
                    Console.WriteLine(numbers.Min());
                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
