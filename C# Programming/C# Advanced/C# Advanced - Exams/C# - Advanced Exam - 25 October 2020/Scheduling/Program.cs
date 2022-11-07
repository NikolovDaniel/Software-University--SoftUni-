using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasksArr = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] threadsArr = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int task = int.Parse(Console.ReadLine());

            Stack<int> tasks = new Stack<int>(tasksArr);
            Queue<int> threads = new Queue<int>(threadsArr);

            while (tasks.Count > 0 && threads.Count > 0)
            {
                if (tasks.Peek() == task)
                {
                    Console.WriteLine($"Thread with value {threads.Peek()} killed task {task}");
                    Console.WriteLine(string.Join(" ", threads));
                    return;
                }
                if (threads.Peek() >= tasks.Peek())
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else if (threads.Peek() < tasks.Peek())
                {
                    threads.Dequeue();
                }
            }
        }
    }
}
