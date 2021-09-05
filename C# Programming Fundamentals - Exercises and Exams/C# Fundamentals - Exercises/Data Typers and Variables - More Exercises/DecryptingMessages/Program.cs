using System;

namespace DecryptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            char[] array = new char[n];

            for (int i = 0; i < n; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                int sum = symbol + key;

                array[i] = (char)sum;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }
        }
    }
}
