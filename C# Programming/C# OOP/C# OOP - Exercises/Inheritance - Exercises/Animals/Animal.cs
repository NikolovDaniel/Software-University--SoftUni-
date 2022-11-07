using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;

        public string Name
        {
            get { return name; }
            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    this.age = value;
                }
            }
        }

        private string gender;

        public string Gender
        {
            get { return gender; }
            set
            {
                if (value == "Male" || value == "Female")
                {
                    this.gender = value;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public abstract string ProduceSound();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.Append($"{this.ProduceSound()}");

            return sb.ToString();
        }
    }
}
