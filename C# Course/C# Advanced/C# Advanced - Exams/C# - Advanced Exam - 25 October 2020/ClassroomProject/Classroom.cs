using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> data;
        public int Count => data.Count;
        public int Capacity { get; set; }

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Student>();
        }

        public string RegisterStudent(Student student)
        {
            if (data.Count < Capacity)
            {
                data.Add(student);
                //Count++;
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            foreach (var student in data)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    data.Remove(student);
                    //Count--;
                    return $"Dismissed student {firstName} {lastName}";
                }
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            string result = string.Empty;

            if (data.Where(x => x.Subject == subject).ToList().Count > 0)
            {
                result += $"Subject: {subject}\n";
                result += "Students:\n";
                foreach (var student in data.Where(x => x.Subject == subject))
                {
                    result += $"{student.FirstName} {student.LastName}\n";
                }
            }
            else
            {
                return "No students enrolled for the subject";
            }

            return result.TrimEnd();
        }

        public int GetStudentCount() => Count;

        public Student GetStudent(string firstName, string lastName) => data
                                                                        .FirstOrDefault(x => x.FirstName == firstName
                                                                        && x.LastName == lastName);

    }
}
