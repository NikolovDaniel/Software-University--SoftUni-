﻿using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core.Contracts
{
    public class Controller : IController
    {

        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = null;

            switch (type)
            {
                case nameof(TunedCar):
                    car = new TunedCar(make, model, VIN, horsePower);
                    break;
                case nameof(SuperCar):
                    car = new SuperCar(make, model, VIN, horsePower);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            cars.Add(car);

            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer racer = null;

            ICar car = cars.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            switch (type)
            {
                case nameof(StreetRacer):
                    racer = new StreetRacer(username, car);
                    break;
                case nameof(ProfessionalRacer):
                    racer = new ProfessionalRacer(username, car);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            racers.Add(racer);

            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.FindBy(racerOneUsername);
            IRacer racerTwo = racers.FindBy(racerTwoUsername);

            if (racerOne == null || racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOne == null ? racerOneUsername : racerTwoUsername));
            }

           return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var racer in racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username))
            {
                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
