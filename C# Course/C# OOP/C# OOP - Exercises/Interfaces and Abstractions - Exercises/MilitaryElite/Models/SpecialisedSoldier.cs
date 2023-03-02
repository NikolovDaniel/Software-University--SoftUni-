using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        public string Corps
        {
            get { return corps; }
            set
            {
                if (value != "Marines" && value != "Airforces")
                {
                    throw new ArgumentException();
                }
                corps = value;
            }
        }


        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine($"Corps: {Corps}");

            return sb.ToString().TrimEnd();
        }

    }
}
