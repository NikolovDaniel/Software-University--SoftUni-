using System;
using System.Linq;

namespace MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int num = int.Parse(Console.ReadLine());
        
            for (int i = 0; i < array.Length; i++)
            {
                for (int a = i + 1; a < array.Length; a++)
                {
                    if (array[i] + array[a] == num)
                    {
                        Console.Write($"{array[i]} {array[a]}");
                        Console.WriteLine();
                    }
                }               
            }
        }
    }
}
