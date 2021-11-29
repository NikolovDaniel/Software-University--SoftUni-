using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races;
        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        public void Add(IRace race)
        {
            IRace currRace = this.GetByName(race.Name);

            if (currRace != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, race.Name));
            }

            races.Add(race);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return races;
        }

        public IRace GetByName(string name)
        {
            return races.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IRace race)
        {
            return races.Remove(race);
        }
    }
}
