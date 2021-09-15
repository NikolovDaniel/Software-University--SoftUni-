using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            double[][] jaggedArr = AddElements(new double[n][]);

            ManipulateMatrix(AnalyzeMatrix(jaggedArr));

        }

        private static void ManipulateMatrix(double[][] jaggedArr)
        {
            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "End")
            {
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                bool isValid = row >= 0 && row <= jaggedArr.Length - 1
                    && col >= 0 && col <= jaggedArr[row].Length - 1;

                if (isValid)
                {
                    if (commands[0] == "Add")
                    {
                        jaggedArr[row][col] += value;
                    }
                    else if (commands[0] == "Subtract")
                    {
                        jaggedArr[row][col] -= value;
                    }
                }

                commands = Console.ReadLine().Split();
            }

            foreach (double[] array in jaggedArr)
            {
                Console.WriteLine(string.Join(" ", array));
            }
        }

        private static double[][] AnalyzeMatrix(double[][] jaggedArr)
        {
            for (int i = 0; i < jaggedArr.Length - 1; i++)
            {
                if (jaggedArr[i].Length == jaggedArr[i + 1].Length)
                {
                    for (int j = 0; j < jaggedArr[i].Length; j++)
                    {
                        jaggedArr[i][j] *= 2;
                    }
                    for (int j = 0; j < jaggedArr[i + 1].Length; j++)
                    {
                        jaggedArr[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < jaggedArr[i].Length; j++)
                    {
                        jaggedArr[i][j] /= 2;
                    }
                    for (int j = 0; j < jaggedArr[i + 1].Length; j++)
                    {
                        jaggedArr[i + 1][j] /= 2;
                    }
                }
            }

            return jaggedArr;
        }

        private static double[][] AddElements(double[][] jaggedArr)
        {
            for (int i = 0; i < jaggedArr.Length; i++)
            {
                double[] arr = ReadInput();

                jaggedArr[i] = arr;
            }

            return jaggedArr;
        }

        private static double[] ReadInput()
        {
            return Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();
        }
    }
}
