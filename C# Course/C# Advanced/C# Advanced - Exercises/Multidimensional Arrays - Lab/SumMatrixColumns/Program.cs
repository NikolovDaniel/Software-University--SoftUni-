using System;
using System.Linq;

namespace SumMatrixColumns
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

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int sum = 0;

                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    sum += matrix[j, i];
                }

                Console.WriteLine(sum);

            }
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
