using System;
using System.Collections.Generic;

namespace RecordUnquieNames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> unquieNames = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                unquieNames.Add(name);
            }

            foreach (var name in unquieNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
