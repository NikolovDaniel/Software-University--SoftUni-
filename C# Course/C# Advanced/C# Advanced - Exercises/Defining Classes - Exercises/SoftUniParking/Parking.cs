using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> carList;
        private int capacity;

        public int Count => this.carList.Count;

        public Parking(int length)
        {
            carList = new List<Car>(length);
            capacity = length;
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var num in RegistrationNumbers)
            {
                this.carList.RemoveAll(x => x.RegistrationNumber == num);
            }
        }
        public Car GetCar(string registrationNumber)
        {
            return carList.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }
        public string RemoveCar(string registrationNumber)
        {

            Car car = carList.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }

            carList.Remove(car);
            return $"Successfully removed {registrationNumber}";

        }
        public string AddCar(Car car)
        {
            List<Car> cars = carList.Where(c => c.RegistrationNumber == car.RegistrationNumber).ToList();

            if (cars.Any())
            {
                return "Car with that registration number, already exists!";
            }

            if (this.carList.Count >= this.capacity)
            {
                return "Parking is full!";
            }

            this.carList.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";

        }
    }
}
