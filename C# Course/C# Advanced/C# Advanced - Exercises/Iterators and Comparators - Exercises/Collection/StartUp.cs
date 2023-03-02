using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> tokens = input.Split().ToList();

            tokens.Remove(tokens[0]);

            ListyIterator<string> newList = new ListyIterator<string>(tokens.ToArray());

            input = Console.ReadLine();

            while (input != "END")
            {

                if (input == "Print")
                {
                    newList.Print();
                }
                else if (input == "HasNext")
                {
                    Console.WriteLine(newList.HasNext());
                }
                else if (input == "Move")
                {
                    Console.WriteLine(newList.Move());
                }
                else if (input == "PrintAll")
                {
                    newList.PrintAll();
                }

                input = Console.ReadLine();
            }
        }
    }
}
