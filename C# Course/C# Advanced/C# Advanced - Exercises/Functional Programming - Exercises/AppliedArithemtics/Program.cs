using System;
using System.Linq;

namespace AppliedArithemtics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int[]> add = n => n.Select(n => n + 1).ToArray();
            Func<int[], int[]> multiply = n => n.Select(n => n * 2).ToArray();
            Func<int[], int[]> subtract = n => n.Select(n => n - 1).ToArray();
            Action<int[]> print = arr => Console.WriteLine(string.Join(" ", arr));

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string cmd = Console.ReadLine();

            while (cmd != "end")
            {

                if (cmd == "add")
                {
                    numbers = add(numbers);
                }
                else if (cmd == "multiply")
                {
                    numbers = multiply(numbers);
                }
                else if (cmd == "subtract")
                {
                   numbers = subtract(numbers);
                }
                else if (cmd == "print")
                {
                    print(numbers);
                }

                cmd = Console.ReadLine();
            }
        }
    }
}
