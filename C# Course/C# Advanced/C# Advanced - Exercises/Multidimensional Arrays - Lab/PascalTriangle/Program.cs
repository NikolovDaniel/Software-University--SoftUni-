using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] triangle = new long[n][];

            for (int i = 0; i < n; i++)
            {

                long[] arr = new long[i + 1];
                arr[0] = 1;
                arr[i] = 1;

                for (int j = 1; j < i; j++)
                {
                    arr[j] = triangle[i - 1][j] + triangle[i - 1][j - 1];
                }

                triangle[i] = arr;

            }

            for (int i = 0; i < triangle.Length; i++)
            {
                Console.WriteLine(string.Join(" ", triangle[i]));
            }
        }
    }
}
