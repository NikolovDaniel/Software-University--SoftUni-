using System;

namespace PawnWars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] matrix = AddElements(new char[8][]);

            int count = 1;

            while (true)
            {
                if (count % 2 != 0)
                {
                    int[] findWhite = FindWhite(matrix);
                    int row = findWhite[0];
                    int col = findWhite[1];

                    if (ValidateLeft(matrix, row, col))
                    {
                            int rowNum = FindRowName(matrix, row - 1, col - 1);
                            string colName = FindColName(matrix, row - 1, col - 1);
                            matrix[row][col] = '-';
                            matrix[row - 1][col - 1] = 'w';

                            Console.WriteLine($"Game over! White capture on {colName + rowNum}.");
                            return;
                    }
                    else if (ValidateRight(matrix, row, col))
                    {
                            int rowNum = FindRowName(matrix, row - 1, col + 1);
                            string colName = FindColName(matrix, row - 1, col + 1);
                            matrix[row][col] = '-';
                            matrix[row - 1][col + 1] = 'w';

                            Console.WriteLine($"Game over! White capture on {colName + rowNum}.");
                            return;
                    }
                    else
                    {
                        if (row - 1 > 0)
                        {
                            matrix[row][col] = '-';
                            matrix[row - 1][col] = 'w';
                        }
                        else
                        {
                            int rowNum = FindRowName(matrix, row, col);
                            string colName = FindColName(matrix, row, col);

                            Console.WriteLine($"Game over! White pawn is promoted to a queen at {colName + (rowNum + 1)}.");
                            return;
                        }
                    }
                }
                else
                {
                    int[] findBlack = FindBlack(matrix);
                    int row = findBlack[0];
                    int col = findBlack[1];

                    if (ValidateLeftBlack(matrix, row, col))
                    {
                        int rowNum = FindRowName(matrix, row + 1, col - 1);
                        string colName = FindColName(matrix, row + 1, col - 1);
                        matrix[row + 1][col - 1] = 'b';
                        matrix[row][col] = '-';
                        Console.WriteLine($"Game over! Black capture on {colName + rowNum}.");
                        return;
                    }
                    else if (ValidateRightBlack(matrix, row, col))
                    {
                        int rowNum = FindRowName(matrix, row + 1, col + 1);
                        string colName = FindColName(matrix, row + 1, col + 1);
                        matrix[row + 1][col + 1] = 'b';
                        matrix[row][col] = '-';
                        Console.WriteLine($"Game over! Black capture on {colName + rowNum}.");
                        return;
                    }
                    else
                    {
                        if (row + 1 < matrix.Length - 1)
                        {
                            matrix[row][col] = '-';
                            matrix[row + 1][col] = 'b';
                        }
                        else
                        {
                            int rowNum = FindRowName(matrix, row, col);
                            string colName = FindColName(matrix, row, col);

                            Console.WriteLine($"Game over! Black pawn is promoted to a queen at {colName + (rowNum - 1)}.");
                            return;
                        }
                    }
                }

                count++;
            }
        }

        private static bool ValidateRightBlack(char[][] matrix, int row, int col)
        {
            if (row + 1 < matrix.Length && col + 1 < matrix[row].Length)
            {
                if (matrix[row + 1][col + 1] == 'w') return true;
            }

            return false;
        }

        private static bool ValidateLeftBlack(char[][] matrix, int row, int col)
        {
            if (row + 1 < matrix.Length && col - 1 >= 0)
            {
                if (matrix[row + 1][col - 1] == 'w') return true;
            }

            return false;
        }

        private static string FindColName(char[][] matrix, int row, int col)
        {
            string result = string.Empty;

            switch (col)
            {
                case 0: result = "a"; break;
                case 1: result = "b"; break;
                case 2: result = "c"; break;
                case 3: result = "d"; break;
                case 4: result = "e"; break;
                case 5: result = "f"; break;
                case 6: result = "g"; break;
                case 7: result = "h"; break;
            }

            return result;
        }
        private static int FindRowName(char[][] matrix, int row, int col)
        {
            int result = 0;
            switch (row)
            {
                case 0: result = 8; break;
                case 1: result = 7; break;
                case 2: result = 6; break;
                case 3: result = 5; break;
                case 4: result = 4; break;
                case 5: result = 3; break;
                case 6: result = 2; break;
                case 7: result = 1; break;
            }
            return result;
        }

        private static bool ValidateLeft(char[][] matrix, int row, int col)
        {
            if (row - 1 >= 0 && col - 1 >= 0)
            {
                if (matrix[row - 1][col - 1] == 'b') return true;
            }
            return false;
        }
        private static bool ValidateRight(char[][] matrix, int row, int col)
        {
            if (row - 1 >= 0 && col + 1 < matrix[row].Length)
            {
                if (matrix[row - 1][col + 1] == 'b') return true;
            }
            return false;
        }

        private static int[] FindWhite(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'w') return new int[] { i, j };
                }
            }

            return null;
        }

        private static int[] FindBlack(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'b') return new int[] { i, j };
                }
            }

            return null;
        }

        private static char[][] AddElements(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                char[] arr = Console.ReadLine().ToCharArray();

                matrix[i] = arr;
            }

            return matrix;
        }
    }
}
