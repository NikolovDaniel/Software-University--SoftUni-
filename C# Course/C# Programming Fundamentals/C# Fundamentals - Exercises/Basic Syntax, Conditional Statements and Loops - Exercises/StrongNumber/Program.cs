using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int[] numbers = new int[number.Length];
            int sum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                numbers[i] = int.Parse(number[i].ToString());
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                int result = numbers[i];
                if (result == 0) result = 1;
                for (int a = numbers[i] - 1; a >= 1; a--)
                {
                    result = result * a;
                }
                sum += result;
            }

            if (sum.ToString() == number)
            {
                Console.WriteLine("yes");
            }
            else Console.WriteLine("no");
        }
    }
}
