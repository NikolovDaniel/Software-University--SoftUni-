using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine()
                                       .Split("|")                                       
                                       .ToList();

            numbers.Reverse();
            List<string> result = new List<string>();


            foreach (var currentItem in numbers)
            {
                string[] nums = currentItem
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

                foreach (var item in nums)
                {
                    result.Add(item);
                }

            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
