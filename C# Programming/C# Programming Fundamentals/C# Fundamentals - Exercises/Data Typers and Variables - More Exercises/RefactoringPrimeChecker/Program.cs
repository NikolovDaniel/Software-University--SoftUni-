using System;

namespace RefactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 2; i <= number; i++)
            {
                bool check = true;

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        check = false;
                        break;
                    }
                }

                if (check) Console.WriteLine($"{i} -> true");
                else Console.WriteLine($"{i} -> false");

            }
        }
    }
}
