using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> Data;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get; private set; }

        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Data = new List<Ski>();
            this.Count = 0;
        }

        public void Add(Ski ski)
        {
            if (this.Data.Count < Capacity)
            {
                this.Data.Add(ski);
                Count++;
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            foreach (var item in this.Data)
            {
                if (item.Manufacturer == manufacturer && item.Model == model)
                {
                    this.Data.Remove(item);
                    Count--;
                    return true;
                }
            }

            return false;
        }

        public Ski GetNewestSki()
        {
            if (this.Data.Count > 0)
            {
                return this.Data.OrderByDescending(x => x.Year).ToList()[0];
            }

            return null;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            foreach (var item in this.Data)
            {
                if (item.Model == model && item.Manufacturer == manufacturer)
                {
                    return item;
                }
            }

            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {this.Name}:");

            foreach (var item in this.Data)
            {
                sb.AppendLine($"{item.Manufacturer} - {item.Model} - {item.Year}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
