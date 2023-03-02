using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomComprarator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> result = new List<int>();

            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, bool> evenNum = n => n % 2 == 0;
            Func<int, bool> oddNum = n => n % 2 != 0;

            int[] odd = arr.Where(n => oddNum(n)).OrderBy(n => n).ToArray();
            int[] even = arr.Where(n => evenNum(n)).OrderBy(n => n).ToArray();

            for (int i = 0; i < even.Length; i++)
            {
                result.Add(even[i]);
            }
            for (int i = 0; i < odd.Length; i++)
            {
                result.Add(odd[i]);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
