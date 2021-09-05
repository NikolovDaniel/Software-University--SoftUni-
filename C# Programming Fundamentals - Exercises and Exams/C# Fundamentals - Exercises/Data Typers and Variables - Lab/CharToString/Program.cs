using System;

namespace CharToString
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] array = new char[3];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = char.Parse(Console.ReadLine());
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }
        }
    }
}
