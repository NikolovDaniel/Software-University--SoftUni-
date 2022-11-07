using System;
using System.Linq;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            string[] moves = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            char[][] matrix = AddElements(new char[n][]);

            int shipsDestroyed = 0;

            for (int i = 0; i < moves.Length; i++)
            {

                string[] currMoves = moves[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(currMoves[0]);
                int col = int.Parse(currMoves[1]);

                matrix = PlayerOneMove(matrix, row, col, ref shipsDestroyed);

                if (SearchPlayerOneShips(matrix) <= 0)
                {
                    Console.WriteLine($"Player Two has won the game! {shipsDestroyed} ships have been sunk in the battle.");
                    return;
                }

                if (SearchPlayerTwoShips(matrix) <= 0)
                {
                    Console.WriteLine($"Player One has won the game! {shipsDestroyed} ships have been sunk in the battle.");
                    return;
                }
            }

            int playerOne = SearchPlayerOneShips(matrix);
            int playerTwo = SearchPlayerTwoShips(matrix);


            Console.WriteLine($"It's a draw! Player One has {playerOne} ships left. Player Two has {playerTwo} ships left.");

        }

        public static int SearchPlayerOneShips(char[][] matrix)
        {
            int count = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == '<')
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        public static int SearchPlayerTwoShips(char[][] matrix)
        {
            int count = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == '>')
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        public static char[][] PlayerOneMove(char[][] matrix, int row, int col, ref int shipsDestroyed)
        {
            if (ValidateIndexes(matrix, row, col))
            {
                if (matrix[row][col] == '#')
                {
                    if (ValidateIndexes(matrix, row - 1, col)) // UP 
                    {
                        if (matrix[row - 1][col] == '<' || matrix[row - 1][col] == '>')
                        {
                            shipsDestroyed++;
                            matrix[row - 1][col] = 'X';
                        }

                    }
                    if (ValidateIndexes(matrix, row + 1, col)) // DOWN
                    {
                        if (matrix[row + 1][col] == '<' || matrix[row + 1][col] == '>')
                        {
                            shipsDestroyed++;
                            matrix[row + 1][col] = 'X';
                        }

                    }
                    if (ValidateIndexes(matrix, row, col - 1)) // LEFT
                    {
                        if (matrix[row][col - 1] == '<' || matrix[row][col - 1] == '>')
                        {
                            shipsDestroyed++;
                            matrix[row][col - 1] = 'X';
                        }
                    }
                    if (ValidateIndexes(matrix, row, col + 1)) // RIGHT
                    {
                        if (matrix[row][col + 1] == '<' || matrix[row][col + 1] == '>')
                        {
                            shipsDestroyed++;
                            matrix[row][col + 1] = 'X';
                        }
                    }
                    if (ValidateIndexes(matrix, row - 1, col - 1)) // TOP LEFT
                    {
                        if (matrix[row - 1][col - 1] == '<' || matrix[row - 1][col - 1] == '>')
                        {
                            shipsDestroyed++;
                            matrix[row - 1][col - 1] = 'X';
                        }
                    }
                    if (ValidateIndexes(matrix, row + 1, col + 1)) // DOWN RIGHT
                    {
                        if (matrix[row + 1][col + 1] == '<' || matrix[row + 1][col + 1] == '>')
                        {
                            shipsDestroyed++;
                            matrix[row + 1][col + 1] = 'X';
                        }
                    }
                    if (ValidateIndexes(matrix, row - 1, col + 1)) // TOP RIGHT
                    {
                        if (matrix[row - 1][col + 1] == '<' || matrix[row - 1][col + 1] == '>')
                        {
                            shipsDestroyed++;
                            matrix[row - 1][col + 1] = 'X';
                        }
                    }
                    if (ValidateIndexes(matrix, row + 1, col - 1)) // DOWN LEFT
                    {
                        if (matrix[row + 1][col - 1] == '<' || matrix[row + 1][col - 1] == '>')
                        {
                            shipsDestroyed++;
                            matrix[row + 1][col - 1] = 'X';
                        }
                    }
                    matrix[row][col] = 'X';
                }
                else if (matrix[row][col] == '>' || matrix[row][col] == '<')
                {
                    matrix[row][col] = 'X';
                    shipsDestroyed++;
                }
             }

            return matrix;
        }
        public static bool ValidateIndexes(char[][] matrix, int row, int col)
        {
            if ((row >= 0 && row < matrix.Length) && (col >= 0 && col < matrix[row].Length))
            {
                return true;
            }
            return false;
        }

        public static char[][] AddElements(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                char[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                matrix[i] = arr;
            }

            return matrix;
        }

    }
}
