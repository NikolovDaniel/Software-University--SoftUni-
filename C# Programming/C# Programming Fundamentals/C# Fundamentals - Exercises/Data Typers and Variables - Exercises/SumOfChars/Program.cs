using System;

namespace SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[] array = new char[n];

            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = char.Parse(Console.ReadLine());
                sum += array[i];
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
