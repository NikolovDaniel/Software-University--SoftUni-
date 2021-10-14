using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] hatsArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] scarfsArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> hats = new Stack<int>(hatsArray);
            Queue<int> scarfs = new Queue<int>(scarfsArray);

            List<int> result = new List<int>();

            while (true)
            {
                if (hats.Count > 0 && scarfs.Count > 0)
                {
                    if (hats.Peek() > scarfs.Peek())
                    {
                        result.Add(hats.Pop() + scarfs.Dequeue());
                    }
                    else if (scarfs.Peek() > hats.Peek())
                    {
                        hats.Pop();
                    }
                    else if (scarfs.Peek() == hats.Peek())
                    {
                        scarfs.Dequeue();
                        hats.Push(hats.Pop() + 1);
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"The most expensive set is: {result.OrderByDescending(x => x).ToList()[0]}");
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
