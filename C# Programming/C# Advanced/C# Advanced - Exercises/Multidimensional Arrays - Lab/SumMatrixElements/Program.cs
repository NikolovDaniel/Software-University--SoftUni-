using System;
using System.Linq;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = ReadInput();

            int[,] matrix = new int[sizes[0], sizes[1]];

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(GetSum(AddElementsToMatrix(matrix, sizes[0], sizes[1])));

        }

        public static int GetSum(int[,] matrix)
        {
            int sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                }
            }
            return sum;
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
