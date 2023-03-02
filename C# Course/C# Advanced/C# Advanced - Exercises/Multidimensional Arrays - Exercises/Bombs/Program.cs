using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = FillMatrix(new int[n, n]);

            string[] indexes = Console.ReadLine().Split();

            for (int i = 0; i < indexes.Length; i++)
            {
                int[] arr = indexes[i].Split(",").Select(int.Parse).ToArray();
                int row = arr[0];
                int col = arr[1];

                matrix = ExplodeBombs(matrix, row, col);
            }

            PrintSumAndCells(matrix);
            PrintMatrix(matrix);
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
        public static void PrintSumAndCells(int[,] matrix)
        {
            int sum = 0;
            int aliveCells = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");
        }
        public static int[,] ExplodeBombs(int[,] matrix, int row, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == row && j == col && matrix[i,j] > 0)
                    {
                        int value = matrix[i, j];
                        if (LeftInside(matrix, i, j)) matrix[i, j - 1] -= value;
                        if (RightInside(matrix, i, j)) matrix[i, j + 1] -= value;
                        if (UpInside(matrix, i, j)) matrix[i + 1, j] -= value;
                        if (DownInside(matrix, i, j)) matrix[i - 1, j] -= value;
                        if (DiagonalDownLeft(matrix, i, j)) matrix[i - 1, j - 1] -= value;
                        if (DiagonalDownRight(matrix, i, j)) matrix[i - 1, j + 1] -= value;
                        if (DiagonalUpLeft(matrix, i, j)) matrix[i + 1, j - 1] -= value;
                        if (DiagonalUpRight(matrix, i, j)) matrix[i + 1, j + 1] -= value;

                        matrix[i, j] = 0;
                    }
                }
            }

            return matrix;
        }

        public static bool LeftInside(int[,] matrix, int row, int col)
        {
            if (col - 1 >= 0 && matrix[row, col - 1] > 0) return true;
            else return false;
        }
        public static bool RightInside(int[,] matrix, int row, int col)
        {
            if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] > 0) return true;
            else return false;
        }
        public static bool UpInside(int[,] matrix, int row, int col)
        {
            if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] > 0) return true;
            else return false;
        }
        public static bool DownInside(int[,] matrix, int row, int col)
        {
            if (row - 1 >= 0 && matrix[row - 1, col] > 0) return true;
            else return false;
        }
        public static bool DiagonalUpLeft(int[,] matrix, int row, int col)
        {
            if ((col - 1 >= 0 && row + 1 < matrix.GetLength(0)) && matrix[row + 1, col - 1] > 0) return true;
            else return false;
        }
        public static bool DiagonalUpRight(int[,] matrix, int row, int col)
        {
            if ((col + 1 < matrix.GetLength(1) && row + 1 < matrix.GetLength(0)) && matrix[row + 1, col + 1] > 0) return true;
            else return false;
        }
        public static bool DiagonalDownLeft(int[,] matrix, int row, int col)
        {
            if ((col - 1 >= 0 && row - 1 >= 0) && matrix[row - 1, col - 1] > 0) return true;
            else return false;
        }
        public static bool DiagonalDownRight(int[,] matrix, int row, int col)
        {
            if ((col + 1 < matrix.GetLength(1) && row - 1 >= 0) && matrix[row - 1, col + 1] > 0) return true;
            else return false;
        }
        public static int[,] FillMatrix(int[,] matrix)
        {

            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            return matrix;
        }
    }
}
