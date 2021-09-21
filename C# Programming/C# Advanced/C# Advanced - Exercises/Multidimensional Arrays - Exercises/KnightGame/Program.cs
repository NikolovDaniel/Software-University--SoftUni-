using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = FillMatrix(new char[n, n]);

            int knights = RemoveKnights(matrix);

            Console.WriteLine(knights);
        }

        private static int RemoveKnights(char[,] matrix)
        {
            int count = 0;
            int currDanger = 0;
            int maxDanger = -1;
            int maxDangerRow = 0;
            int maxDangerCol = 0;

            while (true)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            if (UpLeftInside(matrix, row, col))
                            {
                                currDanger++;
                            }
                            if (UpRightInside(matrix, row, col))
                            {
                                currDanger++;
                            }
                            if (DownLeftInside(matrix, row, col))
                            {
                                currDanger++;
                            }
                            if (DownRightInside(matrix, row, col))
                            {
                                currDanger++;
                            }
                            if (LeftDownInside(matrix, row, col))
                            {
                                currDanger++;
                            }
                            if (LeftUpInside(matrix, row, col))
                            {
                                currDanger++;
                            }
                            if (RightDownInside(matrix, row, col))
                            {
                                currDanger++;
                            }
                            if (RightUpInside(matrix, row, col))
                            {
                                currDanger++;
                            }
                        }
                        if (currDanger > maxDanger)
                        {
                            maxDanger = currDanger;
                            maxDangerRow = row;
                            maxDangerCol = col;
                        }
                        currDanger = 0;
                    }
                }
                if (maxDanger != 0)
                {
                    matrix[maxDangerRow, maxDangerCol] = '0';
                    count++;
                    maxDanger = 0;
                }
                else
                {
                    return count;
                }
            }
        }
        private static bool UpLeftInside(char[,] matrix, int row, int col)
        {

            if ((row + 2 < matrix.GetLength(0) && col - 1 >= 0) && matrix[row + 2, col - 1] == 'K') return true;
            else return false;

        }
        private static bool UpRightInside(char[,] matrix, int row, int col)
        {
            if ((row + 2 < matrix.GetLength(0) && col + 1 < matrix.GetLength(1)) && matrix[row + 2, col + 1] == 'K') return true;
            else return false;
        }
        private static bool DownLeftInside(char[,] matrix, int row, int col)
        {
            if ((row - 2 >= 0 && col - 1 >= 0) && matrix[row - 2, col - 1] == 'K') return true;
            else return false;
        }
        private static bool DownRightInside(char[,] matrix, int row, int col)
        {
            if ((row - 2 >= 0 && col + 1 < matrix.GetLength(1)) && matrix[row - 2, col + 1] == 'K') return true;
            else return false;
        }
        private static bool LeftUpInside(char[,] matrix, int row, int col)
        {
            if ((row + 1 < matrix.GetLength(0) && col - 2 >= 0) && matrix[row + 1, col - 2] == 'K') return true;
            else return false;
        }
        private static bool RightUpInside(char[,] matrix, int row, int col)
        {
            if ((row + 1 < matrix.GetLength(0) && col + 2 < matrix.GetLength(1)) && matrix[row + 1, col + 2] == 'K') return true;
            else return false;
        }
        private static bool LeftDownInside(char[,] matrix, int row, int col)
        {
            if ((row - 1 >= 0 && col - 2 >= 0) && matrix[row - 1, col - 2] == 'K') return true;
            else return false;
        }
        private static bool RightDownInside(char[,] matrix, int row, int col)
        {
            if ((row - 1 >= 0 && col + 2 < matrix.GetLength(1)) && matrix[row - 1, col + 2] == 'K') return true;
            else return false;
        }

        private static char[,] FillMatrix(char[,] matrix)
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] arr = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            return matrix;
        }
    }
}

