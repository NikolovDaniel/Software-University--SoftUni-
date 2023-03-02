using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        public List<Soldier> Privates { get; private set; }
        public LeutenantGeneral(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<Soldier>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (var soldier in Privates)
            {
                sb.AppendLine("  " + soldier.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
