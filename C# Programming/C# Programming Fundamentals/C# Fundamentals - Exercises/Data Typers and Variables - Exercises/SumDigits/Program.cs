using System;
using System.Linq;

namespace SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();

            int[] array = new int[numbers.Length];
            char num = ' ';
            int sum = 0;


            for (int i = 0; i < array.Length; i++)
            {
                num = numbers[i];
                array[i] = int.Parse(num.ToString());
                sum += array[i];
            }

            Console.WriteLine(sum);
        }
    }
}
