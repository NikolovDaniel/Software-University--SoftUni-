using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Mission : IMission
    {
        public string CodeName { get; private set; }

        private string state;

        public string State
        {
            get { return state; }
            set
            {
                if (value != "inProgress" && value != "Finished")
                {
                    throw new ArgumentException();
                }

                state = value;
            }
        }


        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }
        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        {
            return $"  Code Name: {CodeName} State: {State}";
        }
    }
}
