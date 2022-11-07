using System;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = AddElements(new char[n][]);

            int dollars = 0;

            while (dollars < 50)
            {

                int[] findPlayer = FindPlayerPosition(matrix);

                if (findPlayer == null)
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    Console.WriteLine($"Money: {dollars}");
                    PrintMatrix(matrix);
                    return;
                }

                int playerRow = findPlayer[0];
                int playerCol = findPlayer[1];

                string direction = Console.ReadLine();

                if (direction == "up")
                {
                    matrix = CalculateUp(matrix, playerRow, playerCol, ref dollars);
                }
                else if (direction == "down")
                {
                    matrix = CalculateDown(matrix, playerRow, playerCol, ref dollars);
                }
                else if (direction == "left")
                {
                    matrix = CalculateLeft(matrix, playerRow, playerCol, ref dollars);
                }
                else if (direction == "right")
                {
                    matrix = CalculateRight(matrix, playerRow, playerCol, ref dollars);
                }
            }

            Console.WriteLine("Good news! You succeeded in collecting enough money!");
            Console.WriteLine($"Money: {dollars}");
            PrintMatrix(matrix);
        }

        private static char[][] CalculateUp(char[][] matrix, int playerRow, int playerCol, ref int dollars)
        {
            if (ValidateUp(playerRow))
            {
                matrix[playerRow][playerCol] = '-';

                if (matrix[playerRow - 1][playerCol] == 'O')
                {
                    int[] otherPillar = FindSecondPillar(matrix, playerRow - 1, playerCol);
                    int pillarRow = otherPillar[0];
                    int pillarCol = otherPillar[1];

                    matrix[playerRow - 1][playerCol] = '-';
                    matrix[pillarRow][pillarCol] = 'S';
                }
                else if (matrix[playerRow - 1][playerCol] == '-')
                {
                    matrix[playerRow - 1][playerCol] = 'S';
                }
                else
                {
                    dollars += int.Parse(matrix[playerRow - 1][playerCol].ToString());
                    matrix[playerRow - 1][playerCol] = 'S';
                }
            }
            else
            {
                matrix[playerRow][playerCol] = '-';
            }

            return matrix;
        }

        private static bool ValidateUp(int row)
        {
            if (row - 1 >= 0) return true;
            return false;
        }
        private static char[][] CalculateDown(char[][] matrix, int playerRow, int playerCol, ref int dollars)
        {
            if (ValidateDown(matrix, playerRow))
            {
                matrix[playerRow][playerCol] = '-';

                if (matrix[playerRow + 1][playerCol] == 'O')
                {
                    int[] otherPillar = FindSecondPillar(matrix, playerRow + 1, playerCol);
                    int pillarRow = otherPillar[0];
                    int pillarCol = otherPillar[1];

                    matrix[playerRow + 1][playerCol] = '-';
                    matrix[pillarRow][pillarCol] = 'S';
                }
                else if (matrix[playerRow + 1][playerCol] == '-')
                {
                    matrix[playerRow + 1][playerCol] = 'S';
                }
                else
                {
                    dollars += int.Parse(matrix[playerRow + 1][playerCol].ToString());
                    matrix[playerRow + 1][playerCol] = 'S';
                }
            }
            else
            {
                matrix[playerRow][playerCol] = '-';
            }

            return matrix;
        }

        private static bool ValidateDown(char[][] matrix, int row)
        {
            if (row + 1 < matrix.Length ) return true;
            return false;
        }
        private static char[][] CalculateLeft(char[][] matrix, int playerRow, int playerCol, ref int dollars)
        {
            if (ValidateLeft(playerCol))
            {
                matrix[playerRow][playerCol] = '-';

                if (matrix[playerRow][playerCol - 1] == 'O')
                {
                    int[] otherPillar = FindSecondPillar(matrix, playerRow, playerCol - 1);
                    int pillarRow = otherPillar[0];
                    int pillarCol = otherPillar[1];

                    matrix[playerRow][playerCol - 1] = '-';
                    matrix[pillarRow][pillarCol] = 'S';
                }
                else if (matrix[playerRow][playerCol - 1] == '-')
                {
                    matrix[playerRow][playerCol - 1] = 'S';
                }
                else
                {
                    dollars += int.Parse(matrix[playerRow][playerCol - 1].ToString());
                    matrix[playerRow][playerCol - 1] = 'S';
                }
            }
            else
            {
                matrix[playerRow][playerCol] = '-';
            }

            return matrix;
        }

        private static bool ValidateLeft(int col)
        {
            if (col - 1 >= 0) return true;
            return false;
        }
        private static char[][] CalculateRight(char[][] matrix, int playerRow, int playerCol, ref int dollars)
        {
            if (ValidateRight(matrix, playerRow, playerCol))
            {
                matrix[playerRow][playerCol] = '-';

                if (matrix[playerRow][playerCol + 1] == 'O')
                {
                    int[] otherPillar = FindSecondPillar(matrix, playerRow, playerCol + 1);
                    int pillarRow = otherPillar[0];
                    int pillarCol = otherPillar[1];

                    matrix[playerRow][playerCol + 1] = '-';
                    matrix[pillarRow][pillarCol] = 'S';
                }
                else if (matrix[playerRow][playerCol + 1] == '-')
                {
                    matrix[playerRow][playerCol + 1] = 'S';
                }
                else
                {
                    dollars += int.Parse(matrix[playerRow][playerCol + 1].ToString());
                    matrix[playerRow][playerCol + 1] = 'S';
                }
            }
            else
            {
                matrix[playerRow][playerCol] = '-';
            }

            return matrix;
        }

        private static bool ValidateRight(char[][] matrix, int row, int col)
        {
            if (col + 1 < matrix[row].Length) return true;
            return false;
        }
        private static int[] FindSecondPillar(char[][] matrix, int pillarRow, int pillarCol)
        {
            for (int i = pillarRow + 1; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'O')
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return null;
        }
        private static int[] FindPlayerPosition(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'S')
                    {
                        return new int[] { i, j };
                    }
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

        private static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
