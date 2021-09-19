using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<double, int> numbersCount = new Dictionary<double, int>();

            for (int i = 0; i < n; i++)
            {
                double num = double.Parse(Console.ReadLine());

                if (numbersCount.ContainsKey(num))
                {
                    numbersCount[num]++;
                }
                else
                {
                    numbersCount.Add(num, 1);
                }
            }

            foreach (var num in numbersCount.Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine(num.Key);
            }
        }
    }
}
