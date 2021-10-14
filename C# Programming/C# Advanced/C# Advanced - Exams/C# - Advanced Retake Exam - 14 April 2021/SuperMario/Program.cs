using System;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            char[][] matrix = AddElements(new char[n][]);

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string direction = commands[0];
                int rowEnemy = int.Parse(commands[1]);
                int colEnemy = int.Parse(commands[2]);

                int rowPlayer = 0;
                int colPlayer = 0;

                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        if (matrix[i][j] == 'M')
                        {
                            rowPlayer = i;
                            colPlayer = j;
                        }
                    }
                }

                matrix[rowEnemy][colEnemy] = 'B';

                if (direction == "W")
                {
                    lives -= 1;

                    if (ValidateUp(rowPlayer))
                    {
                        if (matrix[rowPlayer - 1][colPlayer] == 'B')
                        {
                            lives -= 2;

                            if (lives <= 0)
                            {
                                matrix[rowPlayer - 1][colPlayer] = 'X';
                                matrix[rowPlayer][colPlayer] = '-';
                                Console.WriteLine($"Mario died at {rowPlayer - 1};{colPlayer}.");
                                PrintMatrix(matrix);
                                return;
                            }
                            else
                            {
                                matrix[rowPlayer - 1][colPlayer] = 'M';
                                matrix[rowPlayer][colPlayer] = '-';
                            }
                        }
                        else if (matrix[rowPlayer - 1][colPlayer] == 'P')
                        {
                            matrix[rowPlayer - 1][colPlayer] = '-';
                            matrix[rowPlayer][colPlayer] = '-';
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                            PrintMatrix(matrix);
                            return;
                        }
                        else
                        {
                            matrix[rowPlayer - 1][colPlayer] = 'M';
                            matrix[rowPlayer][colPlayer] = '-';
                        }
                    }

                    if (lives <= 0)
                    {
                        matrix[rowPlayer - 1][colPlayer] = 'X'; // MIGHT BE A PROBLEM, IF FAIL, TRY WITHOUT - 1
                        matrix[rowPlayer][colPlayer] = '-';
                        Console.WriteLine($"Mario died at {rowPlayer - 1};{colPlayer}.");
                        PrintMatrix(matrix);
                        return;
                    }
                }
                else if (direction == "S")
                {
                    lives -= 1;

                    if (ValidateDown(matrix, rowPlayer))
                    {
                        if (matrix[rowPlayer + 1][colPlayer] == 'B')
                        {
                            lives -= 2;

                            if (lives <= 0)
                            {
                                matrix[rowPlayer + 1][colPlayer] = 'X';
                                matrix[rowPlayer][colPlayer] = '-';
                                Console.WriteLine($"Mario died at {rowPlayer + 1};{colPlayer}.");
                                PrintMatrix(matrix);
                                return;
                            }
                            else
                            {
                                matrix[rowPlayer + 1][colPlayer] = 'M';
                                matrix[rowPlayer][colPlayer] = '-';
                            }
                        }
                        else if (matrix[rowPlayer + 1][colPlayer] == 'P')
                        {
                            matrix[rowPlayer + 1][colPlayer] = '-';
                            matrix[rowPlayer][colPlayer] = '-';
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                            PrintMatrix(matrix);
                            return;
                        }
                        else
                        {
                            matrix[rowPlayer + 1][colPlayer] = 'M';
                            matrix[rowPlayer][colPlayer] = '-';
                        }
                    }

                    if (lives <= 0)
                    {
                        matrix[rowPlayer + 1][colPlayer] = 'X'; // MIGHT BE A PROBLEM, IF FAIL, TRY WITHOUT - 1
                        matrix[rowPlayer][colPlayer] = '-';
                        Console.WriteLine($"Mario died at {rowPlayer + 1};{colPlayer}.");
                        PrintMatrix(matrix);
                        return;
                    }
                }
                else if (direction == "A")
                {
                    lives -= 1;

                    if (ValidateLeft(colPlayer))
                    {
                        if (matrix[rowPlayer][colPlayer - 1] == 'B')
                        {
                            lives -= 2;

                            if (lives <= 0)
                            {
                                matrix[rowPlayer][colPlayer - 1] = 'X';
                                matrix[rowPlayer][colPlayer] = '-';
                                Console.WriteLine($"Mario died at {rowPlayer};{colPlayer - 1}.");
                                PrintMatrix(matrix);
                                return;
                            }
                            else
                            {
                                matrix[rowPlayer][colPlayer - 1] = 'M';
                                matrix[rowPlayer][colPlayer] = '-';
                            }
                        }
                        else if (matrix[rowPlayer][colPlayer - 1] == 'P')
                        {
                            matrix[rowPlayer][colPlayer - 1] = '-';
                            matrix[rowPlayer][colPlayer] = '-';
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                            PrintMatrix(matrix);
                            return;
                        }
                        else
                        {
                            matrix[rowPlayer][colPlayer - 1] = 'M';
                            matrix[rowPlayer][colPlayer] = '-';
                        }
                    }

                    if (lives <= 0)
                    {
                        matrix[rowPlayer][colPlayer - 1] = 'X'; // MIGHT BE A PROBLEM, IF FAIL, TRY WITHOUT - 1
                        matrix[rowPlayer][colPlayer] = '-';
                        Console.WriteLine($"Mario died at {rowPlayer};{colPlayer - 1}.");
                        PrintMatrix(matrix);
                        return;
                    }
                }
                else if (direction == "D")
                {
                    lives -= 1;

                    if (ValidateRight(matrix, rowPlayer, colPlayer))
                    {
                        if (matrix[rowPlayer][colPlayer + 1] == 'B')
                        {
                            lives -= 2;

                            if (lives <= 0)
                            {
                                matrix[rowPlayer][colPlayer + 1] = 'X';
                                matrix[rowPlayer][colPlayer] = '-';
                                Console.WriteLine($"Mario died at {rowPlayer};{colPlayer + 1}.");
                                PrintMatrix(matrix);
                                return;
                            }
                            else
                            {
                                matrix[rowPlayer][colPlayer + 1] = 'M';
                                matrix[rowPlayer][colPlayer] = '-';
                            }
                        }
                        else if (matrix[rowPlayer][colPlayer + 1] == 'P')
                        {
                            matrix[rowPlayer][colPlayer + 1] = '-';
                            matrix[rowPlayer][colPlayer] = '-';
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                            PrintMatrix(matrix);
                            return;
                        }
                        else
                        {
                            matrix[rowPlayer][colPlayer + 1] = 'M';
                            matrix[rowPlayer][colPlayer] = '-';
                        }
                    }

                    if (lives <= 0)
                    {
                        matrix[rowPlayer][colPlayer + 1] = 'X'; // MIGHT BE A PROBLEM, IF FAIL, TRY WITHOUT - 1
                        matrix[rowPlayer][colPlayer] = '-';
                        Console.WriteLine($"Mario died at {rowPlayer};{colPlayer + 1}.");
                        PrintMatrix(matrix);
                        return;
                    }
                }

            }
        }
        public static bool ValidateUp(int row)
        {
            if (row - 1 >= 0) return true;
            return false;
        }
        public static bool ValidateDown(char[][] matrix, int row)
        {
            if (row + 1 < matrix.Length) return true;
            return false;
        }
        public static bool ValidateLeft(int col)
        {
            if (col - 1 >= 0) return true;
            return false;
        }
        public static bool ValidateRight(char[][] matrix, int row, int col)
        {
            if (col + 1 < matrix[row].Length) return true;
            return false;
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
        public static char[][] AddElements(char[][] matrix)
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
