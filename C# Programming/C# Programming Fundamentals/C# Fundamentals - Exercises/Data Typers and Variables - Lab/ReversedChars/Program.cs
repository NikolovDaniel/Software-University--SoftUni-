using System;
using System.Linq;

namespace ReversedChars
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

            for (int i = array.Length - 1; i >= 0; i--)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
