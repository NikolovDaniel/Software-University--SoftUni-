using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double[], double> smallestNum = GetMin;

            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Console.WriteLine(smallestNum(nums));
        }

        private static double GetMin(double[] arr)
        {
            double minNum = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < minNum)
                {
                    minNum = arr[i];
                }
            }

            return minNum;
        }
    }
}
