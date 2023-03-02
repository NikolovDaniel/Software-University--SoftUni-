using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                list.Add(input);
            }

            Box<string> listElements = new Box<string>(list);

            string inpt = Console.ReadLine();

            Console.WriteLine(listElements.CountGreaterElements(list, inpt));
        }
    }
}
