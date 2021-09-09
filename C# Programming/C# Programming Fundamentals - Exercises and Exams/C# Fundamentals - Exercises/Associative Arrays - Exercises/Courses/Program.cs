using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                    .Split(" : ");

            Dictionary<string, List<string>> courseStudents = new Dictionary<string, List<string>>();

            while (input[0] != "end")
            {

                string course = input[0];
                string name = input[1];

                if (courseStudents.ContainsKey(course))
                {
                    courseStudents[course].Add(name);
                }
                else
                {
                    courseStudents.Add(course, new List<string>() { name });
                }
                          
                input = Console.ReadLine()
                               .Split(" : ");
            }

            foreach (var item in courseStudents.OrderByDescending(w => w.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");

                foreach (var name in item.Value.OrderBy(w => w))
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
