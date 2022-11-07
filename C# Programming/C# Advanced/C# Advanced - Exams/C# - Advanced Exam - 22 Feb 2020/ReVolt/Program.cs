using System;
using System.Linq;

namespace ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int cmds = int.Parse(Console.ReadLine());

            char[,] matrix = AddElements(new char[n, n]);

            for (int i = 0; i < cmds; i++)
            {
                string commands = Console.ReadLine();
                int[] findPlayer = FindPlayerRowCol(matrix);
                int row = findPlayer[0];
                int col = findPlayer[1];

                if (commands == "up")
                {
                    matrix = CalculateUp(matrix, row, col);
                }
                else if (commands == "down")
                {
                    matrix = CalculateDown(matrix, row, col);
                }
                else if (commands == "left")
                {
                    matrix = CalculateLeft(matrix, row, col);
                }
                else if (commands == "right")
                {
                    matrix = CalculateRight(matrix, row, col);
                }

                bool isFound = false;

                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        if (matrix[k, j] == 'F')
                        {
                            isFound = true;
                        }
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine("Player won!");
                    PrintMatrix(matrix);
                    return;
                }
            }

            Console.WriteLine("Player lost!");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    Console.Write(matrix[j, k]);
                }
                Console.WriteLine();
            }
        }

        public static char[,] CalculateUp(char[,] matrix, int row, int col)
        {
            if (ValidateUp(matrix, row))
            {
                if (matrix[row - 1, col] == 'B')
                {
                    if (ValidateUp(matrix, row - 1))
                    {
                        matrix[row, col] = '-';
                        matrix[row - 2, col] = 'f';
                    }
                    else
                    {
                        matrix[row, col] = '-';
                        matrix[matrix.GetLength(0) - 1, col] = 'f';
                    }
                }
                else if (matrix[row - 1, col] == 'T') 
                {
                    matrix[row, col] = 'f';
                }
                else
                {
                    matrix[row, col] = '-';
                    matrix[row - 1, col] = 'f';
                }
            }
            else
            {
                matrix[row, col] = '-';
                matrix[matrix.GetLength(0) - 1, col] = 'f';
            }

            return matrix;
        }
        public static bool ValidateUp(char[,] matrix, int row)
        {
            if (row - 1 >= 0) return true;
            return false;
        }
        public static char[,] CalculateDown(char[,] matrix, int row, int col)
        {
            if (ValidateDown(matrix, row))
            {
                if (matrix[row + 1, col] == 'B')
                {
                    if (ValidateDown(matrix, row + 1))
                    {
                        matrix[row, col] = '-';
                        matrix[row + 2, col] = 'f';
                    }
                    else
                    {
                        matrix[row, col] = '-';
                        matrix[0, col] = 'f';
                    }
                }
                else if (matrix[row + 1, col] == 'T')
                {
                    matrix[row, col] = 'f';
                }
                 else
                {
                    matrix[row, col] = '-';
                    matrix[row + 1, col] = 'f';
                }
            }
            else
            {
                matrix[row, col] = '-';
                matrix[0, col] = 'f';
            }

            return matrix;
        }
        public static bool ValidateDown(char[,] matrix, int row)
        {
            if (row + 1 < matrix.GetLength(0)) return true;
            return false;
        }
        public static char[,] CalculateLeft(char[,] matrix, int row, int col)
        {
            if (ValidateLeft(matrix, col))
            {
                if (matrix[row, col - 1] == 'B')
                {
                    if (ValidateLeft(matrix, col - 1))
                    {
                        matrix[row, col] = '-';
                        matrix[row, col - 2] = 'f';
                    }
                    else
                    {
                        matrix[row, col] = '-';
                        matrix[row, matrix.GetLength(1) - 1] = 'f';
                    }
                }
                else if (matrix[row, col - 1] == 'T')
                {
                    matrix[row, col] = 'f';
                }
                else
                {
                    matrix[row, col] = '-';
                    matrix[row, col - 1] = 'f';
                }
            }
            else
            {
                matrix[row, col] = '-';
                matrix[row, matrix.GetLength(1) - 1] = 'f';
            }

            return matrix;
        }
        public static bool ValidateLeft(char[,] matrix, int col)
        {
            if (col - 1 >= 0) return true;
            return false;
        }
        public static char[,] CalculateRight(char[,] matrix, int row, int col)
        {
            if (ValidateRight(matrix, col))
            {
                if (matrix[row, col + 1] == 'B')
                {
                    if (ValidateRight(matrix, col + 1))
                    {
                        matrix[row, col] = '-';
                        matrix[row, col + 2] = 'f';
                    }
                    else
                    {
                        matrix[row, col] = '-';
                        matrix[row, 0] = 'f';
                    }
                }
                else if (matrix[row, col + 1] == 'T')
                {
                    matrix[row, col] = 'f';
                }
                else
                {
                    matrix[row, col] = '-';
                    matrix[row, col + 1] = 'f';
                }
            }
            else
            {
                matrix[row, col] = '-';
                matrix[row, 0] = 'f';
            }

            return matrix;
        }
        public static bool ValidateRight(char[,] matrix, int col)
        {
            if (col + 1 < matrix.GetLength(1)) return true;
            return false;
        }
        private static int[] FindPlayerRowCol(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == 'f')
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return null;
        }
        private static char[,] AddElements(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] arr = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = arr[j];
                }
            }

            return matrix;
        }
    }
}
