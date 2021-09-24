using System;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<string, double> parser = n => double.Parse(n);
            Func<double, double> addVat = n => n += n * 0.20;

            Console.ReadLine()
                .Split(", ")
                .Select(parser)
                .Select(addVat)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n:f2}"));
        }
    }
}
