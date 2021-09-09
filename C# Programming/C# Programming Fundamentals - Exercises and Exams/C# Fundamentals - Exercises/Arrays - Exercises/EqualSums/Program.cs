using System;
using System.Linq;

namespace EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();   

            for (int i = 0; i < array.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                for (int a = 0; a < i; a++)
                {
                    leftSum += array[a];
                }

                for (int b = i + 1; b < array.Length; b++)
                {
                    rightSum += array[b];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
             
            }

            Console.WriteLine("no");
        }
    }
}
