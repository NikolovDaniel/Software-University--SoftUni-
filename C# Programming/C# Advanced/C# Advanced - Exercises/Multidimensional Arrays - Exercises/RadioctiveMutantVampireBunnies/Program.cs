using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioctiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            char[][] matrix = AddElements(new char[sizes[0]][]);

            char[] arr = Console.ReadLine().ToCharArray();

            bool isDead = false;
            bool isWon = false;
            int wdRow = 0;
            int wdCol = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int plRow = 0;
                int plCol = 0;
                bool isFound = false;

                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'P')
                        {
                            plRow = row;
                            plCol = col;
                            isFound = true;
                            break;
                        }
                    }
                    if (isFound) break;
                }

                if (arr[i] == 'L')
                {
                    if (plCol - 1 >= 0)
                    {
                        if (matrix[plRow][plCol - 1] != 'B')
                        {
                            matrix[plRow][plCol - 1] = 'P';
                            matrix[plRow][plCol] = '.';
                        }
                        else
                        {
                            matrix[plRow][plCol] = '.';
                            wdRow = plRow;
                            wdCol = plCol - 1;
                            isDead = true;
                        }
                    }
                    else
                    {
                        matrix[plRow][plCol] = '.';
                        wdRow = plRow;
                        wdCol = plCol;
                        isWon = true;
                    }
                }
                else if (arr[i] == 'R')
                {
                    if (plCol + 1 < matrix[plRow].Length)
                    {
                        if (matrix[plRow][plCol + 1] != 'B')
                        {
                            matrix[plRow][plCol + 1] = 'P';
                            matrix[plRow][plCol] = '.';
                        }
                        else
                        {
                            matrix[plRow][plCol] = '.';
                            wdRow = plRow;
                            wdCol = plCol + 1;
                            isDead = true;
                        }
                    }
                    else
                    {
                        matrix[plRow][plCol] = '.';
                        wdRow = plRow;
                        wdCol = plCol;
                        isWon = true;
                    }
                }
                else if (arr[i] == 'U')
                {
                    if (plRow - 1 >= 0)
                    {
                        if (matrix[plRow - 1][plCol] != 'B')
                        {
                            matrix[plRow - 1][plCol] = 'P';
                            matrix[plRow][plCol] = '.';
                        }
                        else
                        {
                            matrix[plRow][plCol] = '.';
                            wdRow = plRow - 1;
                            wdCol = plCol;
                            isDead = true;
                        }
                    }
                    else
                    {
                        matrix[plRow][plCol] = '.';
                        wdRow = plRow;
                        wdCol = plCol;
                        isWon = true;
                    }
                }
                else if (arr[i] == 'D')
                {
                    if (plRow + 1 < matrix.Length)
                    {
                        if (matrix[plRow + 1][plCol] != 'B')
                        {
                            matrix[plRow + 1][plCol] = 'P';
                            matrix[plRow][plCol] = '.';
                        }
                        else
                        {
                            matrix[plRow][plCol] = '.';
                            wdRow = plRow + 1;
                            wdCol = plCol;
                            isDead = true;
                        }
                    }
                    else
                    {
                        matrix[plRow][plCol] = '.';
                        wdRow = plRow;
                        wdCol = plCol;
                        isWon = true;
                    }
                }

                Queue<int[]> bunniesIndex = new Queue<int[]>();

                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'B')
                        {
                            bunniesIndex.Enqueue(new int[] { row, col });
                        }
                    }
                }

                while (bunniesIndex.Count > 0)
                {
                    int[] size = bunniesIndex.Dequeue();
                    int currRow = size[0];
                    int currCol = size[1];

                        if (currCol - 1 >= 0)
                    {
                        if (matrix[currRow][currCol - 1] == 'P')
                        {
                            wdRow = currRow;
                            wdCol = currCol - 1;
                            isDead = true;
                        }
                        matrix[currRow][currCol - 1] = 'B';
                    }
                    if (currCol + 1 < matrix[currRow].Length)
                    {
                        if (matrix[currRow][currCol + 1] == 'P')
                        {
                            wdRow = currRow;
                            wdCol = currCol + 1;
                            isDead = true;
                        }
                        matrix[currRow][currCol + 1] = 'B';
                    }
                    if (currRow - 1 >= 0)
                    {
                        if (matrix[currRow - 1][currCol] == 'P')
                        {
                            wdRow = currRow - 1;
                            wdCol = currCol;
                            isDead = true;
                        }
                        matrix[currRow - 1][currCol] = 'B';
                    }
                    if (currRow + 1 < matrix.Length)
                    {
                        if (matrix[currRow + 1][currCol] == 'P')
                        {
                            wdRow = currRow + 1;
                            wdCol = currCol;
                            isDead = true;
                        }
                        matrix[currRow + 1][currCol] = 'B';
                    }
                }

                bunniesIndex.Clear();

                if (isWon)
                {
                    isDead = false;
                    break;
                }

                if (isDead)
                {
                    break;
                }
            }

            foreach (var row in matrix)
            {
                foreach (var element in row)
                {
                    Console.Write(element);
                }
                Console.WriteLine();
            }

            if (isDead)
            {
                Console.WriteLine($"dead: {wdRow} {wdCol}");
            }
            if (isWon)
            {
                Console.WriteLine($"won: {wdRow} {wdCol}");
            }

        }
        public static char[][] AddElements(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            return matrix;
        }
    }
}

