using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class Program
    {
        static void Main(string[] args)
        {
            double N1 = double.Parse(Console.ReadLine());
            double N2 = double.Parse(Console.ReadLine());
            char sign = Console.ReadLine()[0];
            double Sum = 0;

            if (sign == '+')
            {
                Sum = N1 + N2;
                if (Sum % 2 == 0)
                {
                    Console.WriteLine($"{N1} {sign} {N2} = {Sum} - even");
                }
                else
                {
                    Console.WriteLine($"{N1} {sign} {N2} = {Sum} - odd");
                }
            }

            if (sign == '-')
            {
                Sum = N1 - N2;
                if (Sum % 2 == 0)
                {
                    Console.WriteLine($"{N1} {sign} {N2} = {Sum} - even");
                }
                else
                {
                    Console.WriteLine($"{N1} {sign} {N2} = {Sum} - odd");
                }
            }

            if (sign == '*')
            {
                Sum = N1 * N2;
                if (Sum % 2 == 0)
                {
                    Console.WriteLine($"{N1} {sign} {N2} = {Sum} - even");
                }
                else
                {
                    Console.WriteLine($"{N1} {sign} {N2} = {Sum} - odd");
                }
            }

            if (sign == '/')
            {
                Sum = N1 / N2;
                if (N2 == 0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
                else
                {
                    Console.WriteLine($"{N1} {sign} {N2} = {Sum:f2}");
                }

            }
            if (sign == '%')
            {
                Sum = N1 % N2;
                if (N2 == 0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
                else
                {
                    Console.WriteLine($"{N1} {sign} {N2} = {Sum}");
                }
            }
        }
    }
}
