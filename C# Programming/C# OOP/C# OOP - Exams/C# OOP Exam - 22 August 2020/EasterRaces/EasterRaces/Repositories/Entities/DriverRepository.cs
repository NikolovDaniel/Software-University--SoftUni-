using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> drivers;
        public DriverRepository()
        {
            this.drivers = new List<IDriver>();
        }

        public void Add(IDriver driver)
        {
            IDriver newDriver = this.GetByName(driver.Name);

            if (newDriver != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driver.Name));
            }

            drivers.Add(driver);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return drivers;
        }

        public IDriver GetByName(string name)
        {
            return drivers.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IDriver driver)
        {
            return drivers.Remove(driver);
        }
    }
}
