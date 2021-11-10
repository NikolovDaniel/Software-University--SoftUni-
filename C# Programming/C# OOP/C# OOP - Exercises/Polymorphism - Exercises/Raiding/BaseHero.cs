using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        public string Name { get; private set; }
        public int Power { get; private set; }
        public BaseHero(string name, string race)
        {
            this.Name = name;

            switch (race)
            {
                case "Druid": this.Power = 80; break;
                case "Paladin": this.Power = 100; break;
                case "Rogue": this.Power = 80; break;
                case "Warrior": this.Power = 100; break;
            }
        }
        public abstract string CastAbility();
    }
}
