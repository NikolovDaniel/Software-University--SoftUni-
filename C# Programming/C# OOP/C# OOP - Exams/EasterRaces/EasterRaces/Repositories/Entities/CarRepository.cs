using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> cars;

        public CarRepository()
        {
            this.cars = new List<ICar>();
        }

        public void Add(ICar car)
        {
            ICar currCar = this.GetByName(car.Model);

            if (currCar != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, car.Model));
            }

            cars.Add(car);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return cars;
        }

        public ICar GetByName(string name)
        {
            return cars.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(ICar model)
        {
            return cars.Remove(model);
        }
    }
}
