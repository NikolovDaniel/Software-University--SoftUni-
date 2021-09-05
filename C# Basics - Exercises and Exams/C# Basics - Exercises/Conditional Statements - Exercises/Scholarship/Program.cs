using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());
            double minIncome = double.Parse(Console.ReadLine());

            double socialScholarship = Math.Floor ( minIncome * 0.35);
            double highGradeScholarship = Math.Floor ( grade * 25);

            if (income <= minIncome && grade >= 5.5 && highGradeScholarship >= socialScholarship)
            {
                Console.WriteLine($"You get a scholarship for excellent results {highGradeScholarship} BGN");
            }
            else if (income <= minIncome && grade >= 5.5 && highGradeScholarship < socialScholarship)
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
            }
            else if (income <= minIncome && grade > 4.5)
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
            }            
            else if (income > minIncome && grade >= 5.5)
            {
                Console.WriteLine($"You get a scholarship for excellent results {highGradeScholarship} BGN");
            }
            else 
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
