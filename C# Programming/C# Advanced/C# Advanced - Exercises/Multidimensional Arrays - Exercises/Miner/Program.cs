using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] moves = Console.ReadLine().Split();


            char[,] matrix = FillMatrix(new char[size, size]);
            int coalInside = CountCoalInMatrix(matrix);

            int lastRow = 0;
            int lastCol = 0;
            int coalCount = 0;

            for (int i = 0; i < moves.Length; i++)
            {
                bool isFound = false;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 's')
                        {
                            isFound = true;
                            if (CheckIfEnd(matrix, row, col, moves[i]))
                            {
                                int deadRow = 0;
                                int deadCol = 0;
                                if (moves[i] == "up")
                                {
                                    deadRow = row - 1;
                                    deadCol = col;
                                }
                                else if (moves[i] == "down")
                                {
                                    deadRow = row + 1;
                                    deadCol = col;
                                }
                                else if (moves[i] == "left")
                                {
                                    deadRow = row;
                                    deadCol = col - 1;
                                }
                                else if (moves[i] == "right")
                                {
                                    deadRow = row;
                                    deadCol = col + 1;
                                }
                                Console.WriteLine($"Game over! ({deadRow}, {deadCol})");


                                return;
                            }
                            if (UpInsideNoCoal(matrix, row, col, moves[i]))
                            {
                                matrix[row, col] = '*';
                                matrix[row - 1, col] = 's';
                                lastRow = row - 1;
                                lastCol = col;
                            }
                            else if (UpInsideCoal(matrix, row, col, moves[i]))
                            {
                                matrix[row, col] = '*';
                                matrix[row - 1, col] = 's';
                                lastRow = row - 1;
                                lastCol = col;
                                coalCount++;
                            }
                            else if (LeftInsideNoCoal(matrix, row, col, moves[i]))
                            {
                                matrix[row, col] = '*';
                                matrix[row, col - 1] = 's';
                                lastRow = row;
                                lastCol = col - 1;
                            }
                            else if (LeftInsideCoal(matrix, row, col, moves[i]))
                            {
                                matrix[row, col] = '*';
                                matrix[row, col - 1] = 's';
                                lastRow = row;
                                lastCol = col - 1;
                                coalCount++;
                            }
                            else if (RightInsideNoCoal(matrix, row, col, moves[i]))
                            {
                                matrix[row, col] = '*';
                                matrix[row, col + 1] = 's';
                                lastRow = row;
                                lastCol = col + 1;
                            }
                            else if (RightInsideCoal(matrix, row, col, moves[i]))
                            {
                                matrix[row, col] = '*';
                                matrix[row, col + 1] = 's';
                                lastRow = row;
                                lastCol = col + 1;
                                coalCount++;
                            }
                            else if (DownInsideNoCoal(matrix, row, col, moves[i]))
                            {
                                matrix[row, col] = '*';
                                matrix[row + 1, col] = 's';
                                lastRow = row + 1;
                                lastCol = col;
                            }
                            else if (DownInsideCoal(matrix, row, col, moves[i]))
                            {
                                matrix[row, col] = '*';
                                matrix[row + 1, col] = 's';
                                lastRow = row + 1;
                                lastCol = col;
                                coalCount++;
                            }
                        }
                        if (coalCount == coalInside)
                        {
                            Console.WriteLine($"You collected all coals! ({lastRow}, {lastCol})");
                            return;
                        }
                        if (isFound) break;
                    }
                    if (isFound) break;
                }
            }

            Console.WriteLine($"{coalInside - coalCount} coals left. ({lastRow}, {lastCol})");
        }

        public static bool CheckIfEnd(char[,] matrix, int row, int col, string moves)
        {
            if (moves == "up")
            {
                if (row - 1 >= 0 && matrix[row - 1, col] == 'e') return true;
                else return false;
            }
            else if (moves == "down")
            {
                if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] == 'e') return true;
                else return false;
            }
            else if (moves == "left")
            {
                if (col - 1 >= 0 && matrix[row, col - 1] == 'e') return true;
                else return false;
            }
            else if (moves == "right")
            {
                if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] == 'e') return true;
                else return false;
            }
            else return false;
        }
        public static bool UpInsideNoCoal(char[,] matrix, int row, int col, string moves)
        {
            if ((row - 1 >= 0 && matrix[row - 1, col] == '*') && moves == "up") return true;
            else return false;
        }
        public static bool UpInsideCoal(char[,] matrix, int row, int col, string moves)
        {
            if ((row - 1 >= 0 && matrix[row - 1, col] == 'c') && moves == "up") return true;
            else return false;
        }
        public static bool LeftInsideNoCoal(char[,] matrix, int row, int col, string moves)
        {
            if (col - 1 >= 0 && matrix[row, col - 1] == '*' && moves == "left") return true;
            else return false;
        }
        public static bool LeftInsideCoal(char[,] matrix, int row, int col, string moves)
        {
            if (col - 1 >= 0 && matrix[row, col - 1] == 'c' && moves == "left") return true;
            else return false;
        }
        public static bool RightInsideNoCoal(char[,] matrix, int row, int col, string moves)
        {
            if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] == '*' && moves == "right") return true;
            else return false;
        }
        public static bool RightInsideCoal(char[,] matrix, int row, int col, string moves)
        {
            if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] == 'c' && moves == "right") return true;
            else return false;
        }
        public static bool DownInsideNoCoal(char[,] matrix, int row, int col, string moves)
        {
            if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] == '*' && moves == "down") return true;
            else return false;
        }
        public static bool DownInsideCoal(char[,] matrix, int row, int col, string moves)
        {
            if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] == 'c' && moves == "down") return true;
            else return false;
        }
        public static int CountCoalInMatrix(char[,] matrix)
        {
            int count = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'c') count++;
                }
            }

            return count;
        }
        public static char[,] FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] arr = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            return matrix;
        }
    }
}
