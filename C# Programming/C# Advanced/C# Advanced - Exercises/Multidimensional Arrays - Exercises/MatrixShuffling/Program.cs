using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[,] matrix = AddElementsToMatrix(new string[sizes[0], sizes[1]]);

            PrintCommands(matrix);

        }

        public static void PrintCommands(string[,] matrix)
        {

            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "END")
            {

                if (commands[0] == "swap" && commands.Length == 5)
                {
                    int rowOne = int.Parse(commands[1]);
                    int colOne = int.Parse(commands[2]);
                    int rowTwo = int.Parse(commands[3]);
                    int colTwo = int.Parse(commands[4]);

                    bool isInside = rowOne >= 0 && rowOne <= matrix.GetLength(0) - 1
                        && colOne >= 0 && colOne <= matrix.GetLength(1) - 1
                        && rowTwo >= 0 && rowTwo <= matrix.GetLength(0) - 1
                        && colTwo >= 0 && colTwo <= matrix.GetLength(1) - 1;

                    if (isInside)
                    {
                        string currElement = matrix[rowOne, colOne];

                        matrix[rowOne, colOne] = matrix[rowTwo, colTwo];
                        matrix[rowTwo, colTwo] = currElement;

                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                Console.Write($"{matrix[i, j]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                   else
                    {
                        Console.WriteLine("Invalid input!");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                commands = Console.ReadLine().Split();
            }
        }
        public static string[,] AddElementsToMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] arr = ReadInput();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = arr[j];
                }
            }

            return matrix;
        }

        public static string[] ReadInput()
        {
            return Console.ReadLine()
                .Split();
        }
    }
}
