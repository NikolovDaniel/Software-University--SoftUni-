using System;
using System.Linq;

namespace SymbolnMatrix
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            PrintChar(AddElementsToMatrix(matrix, n, n), char.Parse(Console.ReadLine()));

        }
        static void PrintChar(char[,] matrix, char symbol)
        {
            bool isThere = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    if (matrix[i,j] == symbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        isThere = true;
                        break;
                    }
                }
                if (isThere)
                {
                    break;
                }
            }

            if (!isThere)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }

        }
        public static char[,] AddElementsToMatrix(char[,] matrix, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                char[] arr = ReadInput();

                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = arr[j];
                }
            }

            return matrix;
        }
        public static char[] ReadInput()
        {
            string str = Console.ReadLine();

            char[] arr = new char[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                arr[i] = str[i];
            }

            return arr;
        }
    }
}
