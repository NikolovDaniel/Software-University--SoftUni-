using System;

namespace FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberA = double.Parse(Console.ReadLine());
            double numberB = double.Parse(Console.ReadLine());


            double sum = 0;
            bool check = false;

            if (numberA > numberB)
            {
                sum = numberA - numberB;
                if (sum <= 0.000001) check = true;
                else check = false;
            }
            else if (numberB > numberA)
            {
                sum = numberB - numberA;
                if (sum <= 0.000001) check = true;
                else check = false;
            }

            Console.WriteLine(check);         
        }
    }
}
