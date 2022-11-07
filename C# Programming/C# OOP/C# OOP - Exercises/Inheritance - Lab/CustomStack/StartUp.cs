using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] items = new string[] { "A", "B", "C" };
            StackOfStrings stack = new StackOfStrings();

            stack.AddRange(items);

            Console.WriteLine();
        }
    }
}
