using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : Creatures
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Citizen(string name, int age, string id)
            : base(id)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
