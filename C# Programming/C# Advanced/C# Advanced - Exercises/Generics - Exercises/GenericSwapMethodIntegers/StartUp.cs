using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<int> list = new List<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                list.Add(input);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Box<int> listOfElements = new Box<int>(list);

            listOfElements.SwapElements(list, indexes[0], indexes[1]);

            Console.WriteLine(listOfElements);
        }
    }
}
