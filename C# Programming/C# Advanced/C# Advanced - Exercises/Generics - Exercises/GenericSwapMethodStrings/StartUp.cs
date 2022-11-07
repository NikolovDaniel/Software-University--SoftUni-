using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<string> list = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                list.Add(input);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Box<string> listOfElements = new Box<string>(list);

            listOfElements.SwapElements(list, indexes[0], indexes[1]);

            Console.WriteLine(listOfElements);
        }
    }
}
