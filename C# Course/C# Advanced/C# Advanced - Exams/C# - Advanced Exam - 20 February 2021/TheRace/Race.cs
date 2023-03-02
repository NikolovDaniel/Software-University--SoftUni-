using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;
        public int Count { get; private set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            data = new List<Racer>();
        }

        public void Add(Racer racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(racer);
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

        public Racer GetOldestRacer() => data.OrderByDescending(x => x.Age).First();

        public Racer GetRacer(string name) => data.FirstOrDefault(x => x.Name == name);

        public Racer GetFastestRacer() => data.OrderByDescending(x => x.Car.Speed).First();

        public string Report()
        {
            string result = $"Racers participating at {this.Name}:";

            foreach (var item in data)
            {
                result += $"\r\n{item.ToString().TrimEnd()}";
            }

            return result;
        }
    }
}
