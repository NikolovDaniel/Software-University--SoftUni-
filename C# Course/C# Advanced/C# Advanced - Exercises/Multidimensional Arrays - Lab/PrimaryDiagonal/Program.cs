using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            Console.WriteLine(GetSum(AddElementsToMatrix(matrix, n, n)));
            
        }

        public static int GetSum(int[,] matrix)
        {
            int sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
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
