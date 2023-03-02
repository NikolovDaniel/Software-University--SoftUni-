using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = n => int.Parse(n);
            Predicate<int> even = n => n % 2 == 0;
            Predicate<int> odd = n => n % 2 != 0;

            int[] points = Console.ReadLine().Split().Select(parser).ToArray();
            string filter = Console.ReadLine();

            List<int> result = new List<int>();

            if (filter == "odd")
            {
                for (int i = Math.Min(points[0], points[1]); i <= Math.Max(points[0], points[1]); i++)
                {
                    if (odd(i)) result.Add(i);
                }
            }
            else
            {
                for (int i = Math.Min(points[0], points[1]); i <= Math.Max(points[0], points[1]); i++)
                {
                    if (even(i)) result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
