using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string snake = Console.ReadLine();

            char[,] matrix = new char[sizes[0], sizes[1]];

            Queue<char> queueSnake = new Queue<char>(snake.ToArray());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row % 2 == 0)
                    {
                        matrix[row, col] = RollTheSnake(queueSnake);
                    }
                    else if (row % 2 != 0)
                    {
                        for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                        {
                            matrix[row, j] = RollTheSnake(queueSnake);
                        }
                        break;
                    }
                }
            }

            PrintMatrix(matrix);

        }
        private static char RollTheSnake(Queue<char> queueSnake)
        {
            char currentSymbol = queueSnake.Dequeue();
            queueSnake.Enqueue(currentSymbol);
            return currentSymbol;
        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
