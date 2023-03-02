using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = AddElements(new char[n][]);

            int snakeFood = 0;

            while (true)
            {
                string direction = Console.ReadLine();

                int[] snake = FindSnake(matrix);

                if (snake == null)
                {
                    Console.WriteLine("Game over!");
                    Console.WriteLine($"Food eaten: {snakeFood}");
                    PrintMatrix(matrix);
                    return;
                }

                int snakeRow = snake[0];
                int snakeCol = snake[1];

                matrix = CalculateMovement(matrix, direction, snakeRow, snakeCol, ref snakeFood);

                if (snakeFood >= 10) break;
            }

            if (snakeFood < 10)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {snakeFood}");
            PrintMatrix(matrix);
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

        private static char[][] CalculateMovement(char[][] matrix, string direction, int snakeRow, int snakeCol, ref int snakeFood)
        {

            if (direction == "up")
            {
                matrix = CalculateUp(matrix, snakeRow, snakeCol, ref snakeFood);
            }
            else if (direction == "down")
            {
                matrix = CalculateDown(matrix, snakeRow, snakeCol, ref snakeFood);
            }
            else if (direction == "left")
            {
                matrix = CalculateLeft(matrix, snakeRow, snakeCol, ref snakeFood);
            }
            else if (direction == "right")
            {
                matrix = CalculateRight(matrix, snakeRow, snakeCol, ref snakeFood);
            }

            return matrix;
        }

        private static char[][] CalculateUp(char[][] matrix, int snakeRow, int snakeCol, ref int snakeFood)
        {
            matrix[snakeRow][snakeCol] = '.';

            if (ValidateUp(snakeRow))
            {

                if (matrix[snakeRow - 1][snakeCol] == '*')
                {
                    matrix[snakeRow - 1][snakeCol] = 'S';
                    snakeFood++;
                }
                else if (matrix[snakeRow - 1][snakeCol] == 'B')
                {
                    int[] nextBurrow = FindBurrow(matrix, snakeRow - 1, snakeCol);
                    int burrRow = nextBurrow[0];
                    int burrCol = nextBurrow[1];

                    matrix[snakeRow - 1][snakeCol] = '.';
                    matrix[burrRow][burrCol] = 'S';
                }
                else
                {
                    matrix[snakeRow - 1][snakeCol] = 'S';
                }
            }

            return matrix;
        }
        private static bool ValidateUp(int row)
        {
            if (row - 1 >= 0) return true;
            return false;
        }

        private static char[][] CalculateDown(char[][] matrix, int snakeRow, int snakeCol, ref int snakeFood)
        {
            matrix[snakeRow][snakeCol] = '.';

            if (ValidateDown(matrix, snakeRow))
            {

                if (matrix[snakeRow + 1][snakeCol] == '*')
                {
                    matrix[snakeRow + 1][snakeCol] = 'S';
                    snakeFood++;
                }
                else if (matrix[snakeRow + 1][snakeCol] == 'B')
                {
                    int[] nextBurrow = FindBurrow(matrix, snakeRow + 1, snakeCol);
                    int burrRow = nextBurrow[0];
                    int burrCol = nextBurrow[1];

                    matrix[snakeRow + 1][snakeCol] = '.';
                    matrix[burrRow][burrCol] = 'S';
                }
                else
                {
                    matrix[snakeRow + 1][snakeCol] = 'S';
                }
            }

            return matrix;
        }
        private static bool ValidateDown(char[][] matrix, int row)
        {
            if (row + 1 < matrix.Length) return true;
            return false;
        }
        private static char[][] CalculateLeft(char[][] matrix, int snakeRow, int snakeCol, ref int snakeFood)
        {
            matrix[snakeRow][snakeCol] = '.';

            if (ValidateLeft(snakeCol))
            {

                if (matrix[snakeRow][snakeCol - 1] == '*')
                {
                    matrix[snakeRow][snakeCol - 1] = 'S';
                    snakeFood++;
                }
                else if (matrix[snakeRow][snakeCol - 1] == 'B')
                {
                    int[] nextBurrow = FindBurrow(matrix, snakeRow, snakeCol - 1);
                    int burrRow = nextBurrow[0];
                    int burrCol = nextBurrow[1];

                    matrix[snakeRow][snakeCol - 1] = '.';
                    matrix[burrRow][burrCol] = 'S';
                }
                else
                {
                    matrix[snakeRow][snakeCol - 1] = 'S';
                }
            }

            return matrix;
        }
        private static bool ValidateLeft(int col)
        {
            if (col - 1 >= 0) return true;
            return false;
        }
        private static char[][] CalculateRight(char[][] matrix, int snakeRow, int snakeCol, ref int snakeFood)
        {
            matrix[snakeRow][snakeCol] = '.';

            if (ValidateRight(matrix, snakeRow, snakeCol))
            {

                if (matrix[snakeRow][snakeCol + 1] == '*')
                {
                    matrix[snakeRow][snakeCol + 1] = 'S';
                    snakeFood++;
                }
                else if (matrix[snakeRow][snakeCol + 1] == 'B')
                {
                    int[] nextBurrow = FindBurrow(matrix, snakeRow, snakeCol + 1);
                    int burrRow = nextBurrow[0];
                    int burrCol = nextBurrow[1];

                    matrix[snakeRow][snakeCol + 1] = '.';
                    matrix[burrRow][burrCol] = 'S';
                }
                else
                {
                    matrix[snakeRow][snakeCol + 1] = 'S';
                }
            }

            return matrix;
        }
        private static bool ValidateRight(char[][] matrix, int row, int col)
        {
            if (col + 1 < matrix[row].Length) return true;
            return false;
        }

        private static int[] FindBurrow(char[][] matrix, int currRow, int currCol)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if ((i != currRow && j != currCol) && matrix[i][j] == 'B')
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return null;
        }
        private static int[] FindSnake(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'S') return new int[] { i, j };
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
