using System;

namespace Literature
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPages = int.Parse(Console.ReadLine());
            double pagesForHour = double.Parse(Console.ReadLine());
            int numDays = int.Parse(Console.ReadLine());

            double readTime = numPages / pagesForHour;
            double hoursNeeded = readTime / numDays;

            Console.WriteLine(hoursNeeded);
        }
    }
}
