using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldestFamilyMember
{
    public class Family
    {

        public List<Person> FamilyMembers { get; set; }

        public Family()
        {
            FamilyMembers = new List<Person>();
        }
        public void AddMember(Person member)
        {
            FamilyMembers.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = FamilyMembers.OrderByDescending(m => m.Age).ToList()[0];

            return oldestPerson;
        }
    }
}
