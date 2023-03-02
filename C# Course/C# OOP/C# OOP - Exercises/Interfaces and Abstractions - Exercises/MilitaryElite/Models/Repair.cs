using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Repair : IRepair
    {
        public string PartName { get; private set; }

        public int Hours { get; private set; }

        public Repair(string partName, int hours)
        {
            this.PartName = partName;
            this.Hours = hours;
        }

        public override string ToString()
        {
            return $"  Part Name: {PartName} Hours Worked: {Hours}";
        }
    }
}
