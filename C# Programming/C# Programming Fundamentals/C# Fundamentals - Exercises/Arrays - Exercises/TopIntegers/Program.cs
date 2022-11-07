using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool check = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentInt = numbers[i];

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (currentInt > numbers[j]) check = true;
                    else
                    {
                        check = false;
                        break;
                    }                                   
                }

                if (check) Console.Write(currentInt + " ");
                check = true;
            }
            
        }
    }
}
