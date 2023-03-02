using System;
using System.Collections.Generic;
using System.Text;

namespace VetClinic
{
    public class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Owner { get; set; }

        public Pet(string name, int age, string owner)
        {
            this.Name = name;
            this.Age = age;
            this.Owner = owner;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {this.Name} Age: {this.Age} Owner: {this.Owner}");

            return sb.ToString().TrimEnd();
        }
    }
}
