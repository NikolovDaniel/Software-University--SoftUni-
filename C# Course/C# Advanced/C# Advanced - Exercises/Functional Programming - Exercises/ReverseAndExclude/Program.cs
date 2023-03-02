using System;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int divider = int.Parse(Console.ReadLine());

            Func<int, bool> moduleDivider = n => n % divider != 0;

            Console.WriteLine(string.Join(" ", numbers.Reverse().Where(moduleDivider)));


        }
    }
}
