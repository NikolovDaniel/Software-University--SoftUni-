using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            //INPUT
            double income = double.Parse(Console.ReadLine());
            double avgGrade = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());
            double scholarship = avgGrade * 25;
            double socialScholarship = minSalary * 0.35;

            //SOLUTION
            if (income >= minSalary)
            {
                if (avgGrade < 5.50)
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }
                else if (avgGrade >= 5.50)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(scholarship)} BGN");
                }
            }
            if (minSalary > income)
            {
                if (avgGrade < 4.50)
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }
                else if (avgGrade > 4.50 && avgGrade < 5.50) 
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
                }
                else if (avgGrade >= 5.50 && scholarship > socialScholarship)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(scholarship)} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
                }
            }
        }
    }
}
