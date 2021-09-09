using System;
using System.Linq;

namespace TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {

            int num = int.Parse(Console.ReadLine());
            int[] array = new int[num];

            int[] result = PrintSequence(array);

            Console.WriteLine(string.Join(" ", result));

        }

        static int[] PrintSequence(int[] array)
        {

            int[] result = array;
            result[0] = 1;


            for (int i = 1; i < result.Length; i++)
            {

                if (i - 1 < 0 || i - 2 < 0)
                {
                    result[i] = result[i - 1];
                }
                else if (i <= 2)
                {
                    result[i] = result[i - 1] + result[i - 2];
                }
                else
                {
                    result[i] = result[i - 1] + result[i - 2] + result[i - 3];
                }

            }

            return result;

        }
    }
}







