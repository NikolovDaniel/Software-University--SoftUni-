using System;

namespace MonthPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] array = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            if (n < 1 || n > 12) Console.WriteLine("Error!");
            else Console.WriteLine(array[n-1]);
        }
    }
}
