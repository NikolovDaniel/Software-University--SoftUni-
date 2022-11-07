using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentsGrades = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (studentsGrades.ContainsKey(name))
                {
                    studentsGrades[name].Add(grade);
                }
                else
                {
                    studentsGrades.Add(name, new List<double>() { grade });
                }
               
            }

            foreach (var name in studentsGrades.Where(x => x.Value.Sum() / x.Value.Count >= 4.50).OrderByDescending(x => x.Value.Sum() / x.Value.Count)) 
            {
                double grade = name.Value.Sum() / name.Value.Count;
                Console.WriteLine($"{name.Key} -> {grade:f2}");
            }
        }
    }
}
