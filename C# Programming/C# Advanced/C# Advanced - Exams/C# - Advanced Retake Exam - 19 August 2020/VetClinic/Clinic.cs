using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;
        public int Count { get; private set; }
        public int Capacity { get; set; }

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            data = new List<Pet>();
            Count = 0;
        }

        public void Add(Pet pet)
        {
            if (data.Count < Capacity)
            {
                data.Add(pet);
                Count++;
            }
        }

        public bool Remove(string name)
        {
            foreach (var pet in data)
            {
                if (pet.Name == name)
                {
                    Count--;
                    data.Remove(pet);
                    return true;
                }
            }

            return false;
        }

        public Pet GetPet(string name, string owner) => data.Where(x => x.Name == name && x.Owner == owner).FirstOrDefault();

        public Pet GetOldestPet() => data.OrderByDescending(x => x.Age).FirstOrDefault();

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The clinic has the following patients:");

            foreach (var pet in this.data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
