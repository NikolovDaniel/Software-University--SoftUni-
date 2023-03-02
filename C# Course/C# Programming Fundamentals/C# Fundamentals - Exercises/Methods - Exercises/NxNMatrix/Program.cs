using System;

namespace NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            PrintMatrix(n);
        }

        static void PrintLine(int n)
        {

            for (int i = 1; i <= n; i++)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
        }

        static void PrintMatrix(int n)
        {

            for (int i = 1; i <= n; i++)
            {
                PrintLine(n);
            }

        }
    }
}
