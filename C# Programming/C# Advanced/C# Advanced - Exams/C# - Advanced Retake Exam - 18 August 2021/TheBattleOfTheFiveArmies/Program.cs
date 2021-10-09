using System;

namespace TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = AddElement(new char[rows][]);

            if (rows == 0)
            {
                return;
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split();

                int rowArmy = 0;
                int colArmy = 0;
                bool isFound = false;

                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        if (matrix[i][j] == 'A')
                        {
                            rowArmy = i;
                            colArmy = j;
                            isFound = true;
                            break;
                        }
                    }
                    if (isFound)
                    {
                        break;
                    }
                }

                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);

                matrix[row][col] = 'O';

                if (commands[0] == "up")
                {
                    if (ValidateUp(rowArmy))
                    {
                        armor -= 1;

                        if (IsOnMordor(matrix, rowArmy - 1, colArmy))
                        {
                            Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                            matrix[rowArmy - 1][colArmy] = '-';
                            matrix[rowArmy][colArmy] = '-';
                            PrintMatrix(matrix);
                            return;
                        }
                        else if (IsOnOrc(matrix, rowArmy - 1, colArmy))
                        {
                            armor -= 2;
                            if (armor <= 0)
                            {
                                PrintDeadDetails(matrix, rowArmy - 1, colArmy, commands[0]);
                                return;
                            }
                            else
                            {
                                matrix[rowArmy - 1][colArmy] = 'A';
                                matrix[rowArmy][colArmy] = '-';
                            }
                        }
                        else if (armor > 0)
                        {
                            matrix[rowArmy - 1][colArmy] = 'A';
                            matrix[rowArmy][colArmy] = '-';
                        }
                        else
                        {
                            matrix[rowArmy - 1][colArmy] = 'X';
                            matrix[rowArmy][colArmy] = '-';
                            Console.WriteLine($"The army was defeated at {rowArmy - 1};{colArmy}.");
                            PrintMatrix(matrix);
                            return;
                        }
                    }
                    else
                    {
                        armor -= 1;
                    }
                }
                else if (commands[0] == "down")
                {
                    if (ValidateDown(matrix, rowArmy))
                    {
                        armor -= 1;

                        if (IsOnMordor(matrix, rowArmy + 1, colArmy))
                        {
                            Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                            matrix[rowArmy + 1][colArmy] = '-';
                            matrix[rowArmy][colArmy] = '-';
                            PrintMatrix(matrix);
                            return;
                        }
                        else if (IsOnOrc(matrix, rowArmy + 1, colArmy))
                        {
                            armor -= 2;
                            if (armor <= 0)
                            {
                                PrintDeadDetails(matrix, rowArmy + 1, colArmy, commands[0]);
                                return;
                            }
                            else
                            {
                                matrix[rowArmy + 1][colArmy] = 'A';
                                matrix[rowArmy][colArmy] = '-';
                            }
                        }
                        else if (armor > 0)
                        {
                            matrix[rowArmy + 1][colArmy] = 'A';
                            matrix[rowArmy][colArmy] = '-';
                        }
                        else
                        {
                            matrix[rowArmy + 1][colArmy] = 'X';
                            matrix[rowArmy][colArmy] = '-';
                            Console.WriteLine($"The army was defeated at {rowArmy + 1};{colArmy}.");
                            PrintMatrix(matrix);
                            return;
                        }
                    }
                    else
                    {
                        armor -= 1;
                    }
                }
                else if (commands[0] == "left")
                {
                    if (ValidateLeft(colArmy))
                    {
                        armor -= 1;

                        if (IsOnMordor(matrix, rowArmy, colArmy - 1))
                        {
                            Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                            matrix[rowArmy][colArmy - 1] = '-';
                            matrix[rowArmy][colArmy] = '-';
                            PrintMatrix(matrix);
                            return;
                        }
                        else if (IsOnOrc(matrix, rowArmy, colArmy - 1))
                        {
                            armor -= 2;
                            if (armor <= 0)
                            {
                                PrintDeadDetails(matrix, rowArmy, colArmy - 1, commands[0]);
                                return;
                            }
                            else
                            {
                                matrix[rowArmy][colArmy - 1] = 'A';
                                matrix[rowArmy][colArmy] = '-';
                            }
                        }
                        else if (armor > 0)
                        {
                            matrix[rowArmy][colArmy - 1] = 'A';
                            matrix[rowArmy][colArmy] = '-';
                        }
                        else
                        {
                            matrix[rowArmy][colArmy - 1] = 'X';
                            matrix[rowArmy][colArmy] = '-';
                            Console.WriteLine($"The army was defeated at {rowArmy};{colArmy - 1}.");
                            PrintMatrix(matrix);
                            return;
                        }
                    }
                    else
                    {
                        armor -= 1;
                    }
                }
                else if (commands[0] == "right")
                {
                    if (ValidateRight(matrix, rowArmy, colArmy))
                    {
                        armor -= 1;

                        if (IsOnMordor(matrix, rowArmy, colArmy + 1))
                        {
                            Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                            matrix[rowArmy][colArmy + 1] = '-';
                            matrix[rowArmy][colArmy] = '-';
                            PrintMatrix(matrix);
                            return;
                        }
                        else if (IsOnOrc(matrix, rowArmy, colArmy + 1))
                        {
                            armor -= 2;
                            if (armor <= 0)
                            {
                                PrintDeadDetails(matrix, rowArmy, colArmy + 1, commands[0]);
                                return;
                            }
                            else
                            {
                                matrix[rowArmy][colArmy + 1] = 'A';
                                matrix[rowArmy][colArmy] = '-';
                            }
                        }
                        else if (armor > 0)
                        {
                            matrix[rowArmy][colArmy + 1] = 'A';
                            matrix[rowArmy][colArmy] = '-';
                        }
                        else
                        {
                            matrix[rowArmy][colArmy + 1] = 'X';
                            matrix[rowArmy][colArmy] = '-';
                            Console.WriteLine($"The army was defeated at {rowArmy};{colArmy + 1}.");
                            PrintMatrix(matrix);
                            return;
                        }
                    }
                    else
                    {
                        armor -= 1;
                    }
                }

                if (armor <= 0)
                {
                    Console.WriteLine($"The army was defeated at {rowArmy};{colArmy}.");
                    matrix[rowArmy][colArmy] = 'X';
                    PrintMatrix(matrix);
                    return;
                }
            }
        }

        public static void PrintDeadDetails(char[][] matrix, int row, int col, string direction)
        {
            if (direction == "up")
            {
                matrix[row][col] = 'X';
                matrix[row + 1][col] = '-';
            }
            else if (direction == "down")
            {
                matrix[row][col] = 'X';
                matrix[row - 1][col] = '-';
            }
            else if (direction == "left")
            {
                matrix[row][col] = 'X';
                matrix[row][col + 1] = '-';
            }
            else if (direction == "right")
            {
                matrix[row][col] = 'X';
                matrix[row][col - 1] = '-';
            }

            Console.WriteLine($"The army was defeated at {row};{col}.");
            PrintMatrix(matrix);
        }
        private static bool IsOnOrc(char[][] matrix, int row, int col)
        {
            if (matrix[row][col] == 'O')
            {
                return true;
            }

            return false;
        }
        private static bool IsOnMordor(char[][] matrix, int row, int col)
        {
            if (matrix[row][col] == 'M')
            {
                return true;
            }

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

        public static bool ValidateUp(int row)
        {
            if (row - 1 >= 0)
            {
                return true;
            }

            return false;
        }
        public static bool ValidateDown(char[][] matrix, int row)
        {
            if (row + 1 < matrix.Length)
            {
                return true;
            }

            return false;
        }
        public static bool ValidateLeft(int col)
        {
            if (col - 1 >= 0)
            {
                return true;
            }

            return false;
        }
        public static bool ValidateRight(char[][] matrix, int row, int col)
        {
            if (col + 1 < matrix[row].Length)
            {
                return true;
            }

            return false;
        }
        public static char[][] AddElement(char[][] matrix)
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
