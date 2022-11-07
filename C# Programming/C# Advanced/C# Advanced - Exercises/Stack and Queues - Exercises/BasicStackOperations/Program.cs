using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int push = array[0];
            int pop = array[1];
            int number = array[2];

            int[] pushArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> numbers = new Stack<int>(pushArray);

            for (int i = 0; i < pop; i++)
            {
                numbers.Pop();
            }

            if (numbers.Contains(number))
            {
                Console.WriteLine("true");
            }
            else if (numbers.Count > 0)
            {
                Console.WriteLine(numbers.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
