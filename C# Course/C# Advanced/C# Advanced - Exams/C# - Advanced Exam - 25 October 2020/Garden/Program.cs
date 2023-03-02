using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] garden = AddElements(new int[sizes[0], sizes[1]]);

            string input = Console.ReadLine();

            List<int[]> rowsAndCols = new List<int[]>();

            while (input != "Bloom Bloom Plow")
            {
                int[] rowAndCol = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (CheckRowAndCol(garden, rowAndCol[0], rowAndCol[1]))
                {
                    rowsAndCols.Add(new int[] { rowAndCol[0], rowAndCol[1] });
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < rowsAndCols.Count; i++)
            {
                int row = rowsAndCols[i][0];
                int col = rowsAndCols[i][1];

                garden = BloomFlowers(garden, row, col);
            }

            PrintGarden(garden);
        }

        private static void PrintGarden(int[,] garden)
        {

            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    Console.Write(garden[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int[,] BloomFlowers(int[,] garden, int row, int col)
        {
            
            for (int i = row; i < garden.GetLength(0); i++)
            {
                if (row == i)
                {
                    garden[row, col] += 1;
                }
                else
                {
                    garden[i, col] += 1;
                }
            }
            for (int i = row; i >= 0; i--)
            {
                if (row == i)
                {
                    continue;
                }
                else
                {
                    garden[i, col] += 1;
                }
            }
            for (int i = col; i < garden.GetLength(0); i++)
            {
                if (col == i)
                {
                    continue;
                }
                else
                {
                    garden[row, i] += 1;
                }
            }
            for (int i = col; i >= 0; i--)
            {
                if (col == i)
                {
                    continue;
                }
                else
                {
                    garden[row, i] += 1;
                }
            }

            return garden;
        }

        private static bool CheckRowAndCol(int[,] garden, int row, int col)
        {
            if ((row >= 0 && row < garden.GetLength(0))
                && (col >= 0 && col < garden.GetLength(1)))
            {
                return true;
            }

            return false;
        }

        private static int[,] AddElements(int[,] garden)
        {
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    garden[i, j] = 0;
                }
            }

            return garden;
        }
    }
}
