using System;

namespace ImplementingStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();

            stack.Push(10);
            stack.Push(20);
            Console.WriteLine($"Stack count: {stack.Count}");
            Console.WriteLine($"Pop result: {stack.Pop()}");
            Console.WriteLine($"Peek result: {stack.Peek()}");
            Console.WriteLine($"Stack count: {stack.Count}");

            var newStack = new CustomStack();

            for (int i = 0; i < 5; i++)
            {
                newStack.Push(i);
            }

            stack.ForEach(n => Console.WriteLine(n));
        }
    }
}
