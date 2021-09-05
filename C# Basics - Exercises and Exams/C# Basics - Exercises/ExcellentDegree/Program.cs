using System;

namespace ExcellentDegree
{
    class Program
    {
        static void Main(string[] args)
        {
            //INPUT 
            double grade = double.Parse(Console.ReadLine());

            if (grade >= 5.50)
            {
                Console.WriteLine("Excellent!");               
            }
            else
            {
                Console.WriteLine();
            }
                
           
        }
    }
}
