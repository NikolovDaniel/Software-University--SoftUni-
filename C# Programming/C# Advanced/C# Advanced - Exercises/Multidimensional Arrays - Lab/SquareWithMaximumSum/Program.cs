using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = ReadInput();

            int[,] matrix = new int[sizes[0], sizes[1]];

            GetSum(AddElementsToMatrix(matrix, sizes[0], sizes[1]));
        }

        static void GetSum(int[,] matrix)
        {
            int maxSum = int.MinValue;
            int mxRow = 0;
            int mxCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = (matrix[row, col] + matrix[row, col + 1]) + (matrix[row + 1, col] + matrix[row + 1, col + 1]);

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        mxRow = row;
                        mxCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[mxRow, mxCol]} {matrix[mxRow, mxCol + 1]}");
            Console.WriteLine($"{matrix[mxRow + 1, mxCol]} {matrix[mxRow + 1, mxCol + 1]}");
            Console.WriteLine($"{maxSum}");
        }

        public static int[,] AddElementsToMatrix(int[,] matrix, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                int[] arr = ReadInput();

                for (int j = 0; j < col; j++)
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
