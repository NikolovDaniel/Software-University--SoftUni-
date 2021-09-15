using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixRows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[matrixRows][];

            for (int i = 0; i < matrixRows; i++)
            {
                int[] arr = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[i] = arr;
            }

            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "END")
            {

                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                if (row < 0 || row > jaggedArray.Length - 1 || col < 0 || col > jaggedArray[row].Length - 1)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (commands[0] == "Add")
                    {
                        jaggedArray[row][col] += value;
                    }
                    else if (commands[0] == "Subtract")
                    {
                        jaggedArray[row][col] -= value;
                    }
                }

                commands = Console.ReadLine().Split();
            }

            foreach (int[] row in jaggedArray)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
    }
}
