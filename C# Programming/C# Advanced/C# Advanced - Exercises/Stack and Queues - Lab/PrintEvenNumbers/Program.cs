using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();       
           
            Queue<int> nums = new Queue<int>(array);

            int count = nums.Count;

            for (int i = 0; i < count; i++)
            {
                int num = nums.Peek();

                if (num % 2 == 1)
                {
                    nums.Dequeue();
                }
                else
                {
                    nums.Enqueue(nums.Dequeue());
                }
            }

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
