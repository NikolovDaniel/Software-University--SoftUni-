using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = sizes[0];
            int m = sizes[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                firstSet.Add(num);
            }
            for (int i = 0; i < m; i++)
            {
                int num = int.Parse(Console.ReadLine());
                secondSet.Add(num);
            }

            List<int> result = new List<int>();

            for (int i = 0; i < firstSet.Count; i++)
            {
                if (secondSet.Contains(firstSet.ElementAt(i)))
                {
                    result.Add(firstSet.ElementAt(i));
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
