using System;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numThree = int.Parse(Console.ReadLine());

            SmallestNumber(numOne, numTwo, numThree);

        }

        static void SmallestNumber(int numOne, int numTwo, int numThree)
        {
            int[] array = new int[] { numOne, numTwo, numThree };

            Array.Sort(array);

            Console.WriteLine(array[0]);

        }
    }
}
