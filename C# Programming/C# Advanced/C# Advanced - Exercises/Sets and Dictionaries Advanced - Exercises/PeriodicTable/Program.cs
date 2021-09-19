using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            HashSet<string> chemicals = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();

                for (int j = 0; j < arr.Length; j++)
                {
                    chemicals.Add(arr[j]);
                }
            }

            Console.Write(string.Join(" ", chemicals.OrderBy(x => x)));


        }
    }
}
