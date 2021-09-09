using System;
using System.Linq;

namespace WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadLine()
                .Split()
                .Where(n => n.Length % 2 == 0)
                .ToList()
                .ForEach(x => Console.WriteLine(x));

        }
    }
}
