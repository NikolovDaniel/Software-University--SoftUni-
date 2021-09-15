using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = ReadInput();

            int[,] matrix = AddElementsToMatrix(new int[sizes[0], sizes[1]]);

            Print3X3Matrix(matrix);

        }

        public static void Print3X3Matrix(int[,] matrix)
        {
            int maxSum = int.MinValue;
            int mxRow = 0;
            int mxCol = 0;

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                int sum = 0;

                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]
                        + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                        + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        mxRow = i;
                        mxCol = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[mxRow, mxCol]} {matrix[mxRow, mxCol + 1]} {matrix[mxRow, mxCol + 2]}");
            Console.WriteLine($"{matrix[mxRow + 1, mxCol]} {matrix[mxRow + 1, mxCol + 1]} {matrix[mxRow + 1, mxCol + 2]}");
            Console.WriteLine($"{matrix[mxRow + 2, mxCol]} {matrix[mxRow + 2, mxCol + 1]} {matrix[mxRow + 2, mxCol + 2]}");
        }
        public static int[,] AddElementsToMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] arr = ReadInput();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = arr[j];
                }
            }

            return matrix;
        }

        public static int[] ReadInput()
        {
            return Console.ReadLine()
                .Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
