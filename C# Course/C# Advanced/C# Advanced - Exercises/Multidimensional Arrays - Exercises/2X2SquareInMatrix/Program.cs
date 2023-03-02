using System;
using System.Linq;

namespace _2X2SquareInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = AddElementsToMatrix(new char[sizes[0], sizes[1]]);

            Console.WriteLine(PrintCountOfSquares(matrix));
        }

        public static int PrintCountOfSquares(char[,] matrix)
        {

            int count = 0;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    char currCh = matrix[i, j];
                    bool isSame = matrix[i, j + 1] == currCh && matrix[i + 1, j] == currCh && matrix[i + 1, j + 1] == currCh;
                    if (isSame)
                    {
                        count++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return count;
        }

        public static char[,] AddElementsToMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] arr = ReadInput();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = arr[j];
                }
            }

            return matrix;
        }

        public static char[] ReadInput()
        {
            return Console.ReadLine()
                .Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
        }
    }
}
