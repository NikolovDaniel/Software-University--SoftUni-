using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public int Count { get; private set; }

        public Race()
        {
            Participants = new List<Car>();
            Count = 0;
        }
        public Race(string name, string type, int laps, int capacity, int maxHorsePower) : this()
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
        }

        public void Add(Car car)
        {
            bool isThere = false;

            foreach (var item in Participants)
            {
                if (item.LicensePlate == car.LicensePlate)
                {
                    isThere = true;
                    break;
                }
            }

            if (!isThere && Participants.Count + 1 <= Capacity && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
                Count++;
            }
        }

        public bool Remove(string licensePlate)
        {
            foreach (var item in Participants)
            {
                if (item.LicensePlate == licensePlate)
                {
                    Participants.Remove(item);
                    Count--;
                    return true;
                }
            }

            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            foreach (var item in Participants)
            {
                if (item.LicensePlate == licensePlate)
                {
                    return item;
                }
            }

            return null;
        }

        public Car GetMostPowerfulCar()
        {
            if (Participants.Count > 0)
            {
                return Participants.OrderByDescending(c => c.HorsePower).ToList()[0];
            }

            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");

            foreach (var item in Participants)
            {
                sb.AppendLine($"Make: {item.Make}");
                sb.AppendLine($"Model: {item.Model}");
                sb.AppendLine($"License Plate: {item.LicensePlate}");
                sb.AppendLine($"Horse Power: {item.HorsePower}");
                sb.AppendLine($"Weight: {item.Weight}");
            }

            return sb.ToString();
        }
    }
}
