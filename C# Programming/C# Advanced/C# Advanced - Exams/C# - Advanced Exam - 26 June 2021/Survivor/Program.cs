using System;
using System.Linq;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = AddElements(new char[n][]);

            string input = Console.ReadLine();

            int myToken = 0;
            int oppToken = 0;

            while (input != "Gong")
            {
                string[] tokens = input.Split();

                if (tokens[0] == "Find")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);

                    if (FindElement(matrix, row, col))
                    {
                        matrix[row][col] = '-';
                        myToken++;
                    }
                }
                else if (tokens[0] == "Opponent")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    string direction = tokens[3];

                    if (direction == "up")
                    {
                        if (ValidateUp(matrix, row, col))
                        {                            
                            if (matrix[row][col] == 'T')
                            {
                                matrix[row][col] = '-';
                                oppToken++;
                            }

                            row -= 1;

                            for (int i = 0; i < 3; i++)
                            {
                                if (matrix[row][col] == 'T')
                                {
                                    matrix[row][col] = '-';
                                    oppToken++;
                                }
                                else
                                {
                                    row -= 1;
                                    continue;
                                }
                                row -= 1;
                                if (row < 0)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        if (ValidateDown(matrix, row, col))
                        {
                            if (matrix[row][col] == 'T')
                            {
                                matrix[row][col] = '-';
                                oppToken++;
                            }

                            row += 1;

                            for (int i = 0; i < 3; i++)
                            {
                                if (matrix[row][col] == 'T')
                                {
                                    matrix[row][col] = '-';
                                    oppToken++;
                                }
                                else
                                {
                                    row += 1;
                                    continue;
                                }
                                row += 1;
                                if (row >= matrix.Length)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        if (ValidateLeft(matrix, row, col))
                        {
                            if (matrix[row][col] == 'T')
                            {
                                matrix[row][col] = '-';
                                oppToken++;
                            }

                            col -= 1;

                            for (int i = 0; i < 3; i++)
                            {
                                if (matrix[row][col] == 'T')
                                {
                                    matrix[row][col] = '-';
                                    oppToken++;
                                }
                                else
                                {
                                    col -= 1;
                                    continue;
                                }
                                col -= 1;
                                if (col < 0)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        if (ValidateRight(matrix, row, col))
                        {
                            if (matrix[row][col] == 'T')
                            {
                                matrix[row][col] = '-';
                                oppToken++;
                            }

                            col += 1;
                            if (ValidateRight(matrix, row, col))
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (matrix[row][col] == 'T')
                                    {
                                        matrix[row][col] = '-';
                                        oppToken++;
                                    }
                                    else
                                    {
                                        col += 1;
                                        continue;
                                    }
                                    col += 1;
                                    if (col >= matrix[row].Length)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            PrintMatrix(matrix);
            Console.WriteLine($"Collected tokens: {myToken}");
            Console.WriteLine($"Opponent's tokens: {oppToken}");
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }

        private static bool ValidateUp(char[][] matrix, int row, int col)
        {
            if ((row >= 0 && row < matrix.Length) && (col >= 0 && col < matrix[row].Length)) return true;
            return false;
        }
        private static bool ValidateDown(char[][] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.Length && (col >= 0 && col < matrix[row].Length)) return true;
            return false;
        }
        private static bool ValidateLeft(char[][] matrix, int row, int col)
        {
            if (col >= 0 && col < matrix[row].Length && (row >= 0 && row < matrix.Length)) return true;
            return false;
        }
        private static bool ValidateRight(char[][] matrix, int row, int col)
        {
            if (col < matrix[row].Length && (row >= 0 && row < matrix.Length)) return true;
            return false;
        }
        private static bool FindElement(char[][] matrix, int row, int col)
        {
            if ((row >= 0 && row < matrix.Length)
                && (col >= 0 && col < matrix[row].Length))
            {
                if (matrix[row][col] == 'T')
                {
                    return true;
                }
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
