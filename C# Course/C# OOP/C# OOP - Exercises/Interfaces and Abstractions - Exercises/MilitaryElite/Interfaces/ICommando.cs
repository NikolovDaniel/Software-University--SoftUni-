using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ICommando
    {
        public List<Mission> Missions { get; }
    }
}