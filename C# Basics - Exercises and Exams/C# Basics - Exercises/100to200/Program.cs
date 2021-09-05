using System;

namespace _100to200
{
    class Program
    {
        static void Main(string[] args)
        {
            //INPUT 
            int number = int.Parse(Console.ReadLine());

            //SOLUTION
            if (number < 100)
            {
                Console.WriteLine("Less than 100");
            }
            else if (number == 100 || number <= 200)
            {
                Console.WriteLine("Between 100 and 200");
            }
            else 
            {
                Console.WriteLine("Greater than 200");
            }     
        }
    }
}
