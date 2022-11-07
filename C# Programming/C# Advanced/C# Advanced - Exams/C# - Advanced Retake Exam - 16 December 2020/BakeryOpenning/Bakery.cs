using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;
        public int Count { get; private set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Employee>();
        }

        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
                Count++;
            }
        }

        public bool Remove(string name)
        {
            foreach (var item in data)
            {
                if (item.Name == name)
                {
                    data.Remove(item);
                    Count--;
                    return true;
                }
            }

            return false;
        }

        public Employee GetOldestEmployee() => data.OrderByDescending(x => x.Age).FirstOrDefault();

        public Employee GetEmployee(string name) => data.FirstOrDefault(x => x.Name == name);
      
        public string Report()
        {
            string result = $"Employees working at Bakery {this.Name}:";

            foreach (var item in data)
            {
                result += $"\n{item.ToString().TrimEnd()}";
            }

            return result;
        }
    }
}
