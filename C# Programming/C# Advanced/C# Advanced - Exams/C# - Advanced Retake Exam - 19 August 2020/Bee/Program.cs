using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] flowers = AddElements(new char[n][]);

            int pollinatedFlowers = 0;

            string input = Console.ReadLine();

            while (input != "End")
            {

                int[] beePosition = FindBeePosition(flowers);

                if (beePosition == null)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                int beeRow = beePosition[0];
                int beeCol = beePosition[1];

                flowers = CalculateMovement(flowers, beeRow, beeCol, input, ref pollinatedFlowers);

                if (FindBeePosition(flowers) == null)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                input = Console.ReadLine();
            }

            PrintMessage(pollinatedFlowers);
            PrintFlowers(flowers);
        }

        private static void PrintMessage(int pollinatedFlowers)
        {
            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }
        }

        private static void PrintFlowers(char[][] flowers)
        {
            for (int i = 0; i < flowers.Length; i++)
            {
                for (int j = 0; j < flowers[i].Length; j++)
                {
                    Console.Write(flowers[i][j]);
                }
                Console.WriteLine();
            }
        }

        private static char[][] CalculateMovement(char[][] flowers, int beeRow, int beeCol, string input, ref int pollinatedFlowers)
        {
            if (input == "up")
            {
                flowers = CalculateUp(flowers, beeRow, beeCol, ref pollinatedFlowers);
            }
            else if (input == "down")
            {
                flowers = CalculateDown(flowers, beeRow, beeCol, ref pollinatedFlowers);
            }
            else if (input == "left")
            {
                flowers = CalculateLeft(flowers, beeRow, beeCol, ref pollinatedFlowers);
            }
            else if (input == "right")
            {
                flowers = CalculateRight(flowers, beeRow, beeCol, ref pollinatedFlowers);
            }

            return flowers;
        }

        private static char[][] CalculateRight(char[][] flowers, int beeRow, int beeCol, ref int pollinatedFlowers)
        {
            flowers[beeRow][beeCol] = '.';

            if (ValidateRight(flowers, beeRow, beeCol))
            {
                if (flowers[beeRow][beeCol + 1] == 'O')
                {
                    if (ValidateRight(flowers, beeRow, beeCol + 1))
                    {
                        flowers[beeRow][beeCol + 1] = '.';

                        if (flowers[beeRow][beeCol + 2] == 'f')
                        {
                            pollinatedFlowers++;
                            flowers[beeRow][beeCol + 2] = 'B';
                        }
                        else
                        {
                            flowers[beeRow][beeCol + 2] = 'B';
                        }
                    }
                    else
                    {
                        flowers[beeRow][beeCol + 1] = '.';
                    }
                }
                else if (flowers[beeRow][beeCol + 1] == 'f')
                {
                    pollinatedFlowers++;
                    flowers[beeRow][beeCol + 1] = 'B';
                }
                else
                {
                    flowers[beeRow][beeCol + 1] = 'B';
                }
            }

            return flowers;
        }

        private static bool ValidateRight(char[][] flowers, int beeRow, int beeCol)
        {
            if (beeCol + 1 < flowers[beeRow].Length) return true;
            return false;
        }
        private static char[][] CalculateLeft(char[][] flowers, int beeRow, int beeCol, ref int pollinatedFlowers)
        {
            flowers[beeRow][beeCol] = '.';

            if (ValidateLeft(beeCol))
            {
                if (flowers[beeRow][beeCol - 1] == 'O')
                {
                    if (ValidateLeft(beeCol - 1))
                    {
                        flowers[beeRow][beeCol - 1] = '.';

                        if (flowers[beeRow][beeCol - 2] == 'f')
                        {
                            pollinatedFlowers++;
                            flowers[beeRow][beeCol - 2] = 'B';
                        }
                        else
                        {
                            flowers[beeRow][beeCol - 2] = 'B';
                        }
                    }
                    else
                    {
                        flowers[beeRow][beeCol - 1] = '.';
                    }
                }
                else if (flowers[beeRow][beeCol - 1] == 'f')
                {
                    pollinatedFlowers++;
                    flowers[beeRow][beeCol - 1] = 'B';
                }
                else
                {
                    flowers[beeRow][beeCol - 1] = 'B';
                }
            }

            return flowers;
        }

        private static bool ValidateLeft(int beeCol)
        {
            if (beeCol - 1 >= 0) return true;
            return false;
        }

        private static char[][] CalculateDown(char[][] flowers, int beeRow, int beeCol, ref int pollinatedFlowers)
        {
            flowers[beeRow][beeCol] = '.';

            if (ValidateDown(flowers, beeRow))
            {
                if (flowers[beeRow + 1][beeCol] == 'O')
                {
                    if (ValidateDown(flowers, beeRow + 1))
                    {
                        flowers[beeRow + 1][beeCol] = '.';

                        if (flowers[beeRow + 2][beeCol] == 'f')
                        {
                            pollinatedFlowers++;
                            flowers[beeRow + 2][beeCol] = 'B';
                        }
                        else
                        {
                            flowers[beeRow + 2][beeCol] = 'B';
                        }
                    }
                    else
                    {
                        flowers[beeRow + 1][beeCol] = '.';
                    }
                }
                else if (flowers[beeRow + 1][beeCol] == 'f')
                {
                    pollinatedFlowers++;
                    flowers[beeRow + 1][beeCol] = 'B';
                }
                else
                {
                    flowers[beeRow + 1][beeCol] = 'B';
                }
            }

            return flowers;
        }

        private static bool ValidateDown(char[][] flowers, int beeRow)
        {
            if (beeRow + 1 < flowers.Length) return true;
            return false;
        }

        private static char[][] CalculateUp(char[][] flowers, int beeRow, int beeCol, ref int pollinatedFlowers)
        {

            flowers[beeRow][beeCol] = '.';

            if (ValidateUp(beeRow))
            {
                if (flowers[beeRow - 1][beeCol] == 'O')
                {
                    if (ValidateUp(beeRow - 1))
                    {
                        flowers[beeRow - 1][beeCol] = '.';

                        if (flowers[beeRow - 2][beeCol] == 'f')
                        {
                            pollinatedFlowers++;
                            flowers[beeRow - 2][beeCol] = 'B';
                        }
                        else
                        {
                            flowers[beeRow - 2][beeCol] = 'B';
                        }
                    }
                    else
                    {
                        flowers[beeRow - 1][beeCol] = '.';
                    }
                }
                else if (flowers[beeRow - 1][beeCol] == 'f')
                {
                    pollinatedFlowers++;
                    flowers[beeRow - 1][beeCol] = 'B';
                }
                else
                {
                    flowers[beeRow - 1][beeCol] = 'B';
                }
            }

            return flowers;
        }

        private static bool ValidateUp(int beeRow)
        {
            if (beeRow - 1 >= 0) return true;
            return false;
        }

        private static int[] FindBeePosition(char[][] flowers)
        {
            for (int i = 0; i < flowers.Length; i++)
            {
                for (int j = 0; j < flowers[i].Length; j++)
                {
                    if (flowers[i][j] == 'B')
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return null;
        }

        private static char[][] AddElements(char[][] flowers)
        {

            for (int i = 0; i < flowers.Length; i++)
            {
                char[] arr = Console.ReadLine().ToCharArray();

                flowers[i] = arr;
            }

            return flowers;
        }
    }
}
