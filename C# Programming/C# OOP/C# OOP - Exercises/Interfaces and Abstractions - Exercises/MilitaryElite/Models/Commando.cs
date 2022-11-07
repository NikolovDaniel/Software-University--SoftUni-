using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public List<Mission> Missions { get; private set; }

        public Commando(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<Mission>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine($"Missions:");

            foreach (var mission in Missions)
            {
                sb.AppendLine(mission.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
