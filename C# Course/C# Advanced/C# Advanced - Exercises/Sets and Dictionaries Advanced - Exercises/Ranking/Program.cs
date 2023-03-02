using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> contests = FillContests(new Dictionary<string, string>());

            Dictionary<string, Dictionary<string, int>> studentContests = AddStudents(contests, new Dictionary<string, Dictionary<string, int>>());

            PrintStudents(studentContests);
        }

        public static void PrintStudents(Dictionary<string, Dictionary<string, int>> studentContests)
        {
            foreach (var student in studentContests.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"Best candidate is {student.Key} with total {student.Value.Values.Sum()} points.");
                break;
            }
            Console.WriteLine("Ranking:");
            foreach (var student in studentContests.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);
                foreach (var contest in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
        private static Dictionary<string, Dictionary<string, int>> AddStudents(Dictionary<string, string> contests, Dictionary<string, Dictionary<string, int>> studentContests)
        {
            string input = Console.ReadLine();

            while (input != "end of submissions")
            {
                string[] cmd = input.Split("=>");

                string contest = cmd[0];
                string password = cmd[1];
                string username = cmd[2];
                int points = int.Parse(cmd[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (studentContests.ContainsKey(username))
                    {
                        if (studentContests[username].ContainsKey(contest))
                        {
                            if (studentContests[username][contest] < points)
                            {
                                studentContests[username][contest] = points;
                            }
                        }
                        else
                        {
                            studentContests[username].Add(contest, points);
                        }
                    }
                    else
                    {
                        studentContests.Add(username, new Dictionary<string, int>()
                            {
                                { contest, points }
                            });

                    }
                }

                input = Console.ReadLine();
            }

            return studentContests;
        }
        private static Dictionary<string, string> FillContests(Dictionary<string, string> contests)
        {

            string input = Console.ReadLine();

            while (input != "end of contests")
            {

                string[] cmd = input.Split(":");

                string contest = cmd[0];
                string password = cmd[1];

                contests.Add(contest, password);

                input = Console.ReadLine();
            }

            return contests;
        }
    }
}