using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry race;
        [SetUp]
        public void Setup()
        {
            race = new RaceEntry();
        }

        [Test]
        public void Counter_CheckIfCounterIsZero()
        {
            Assert.That(race.Counter, Is.Zero);
        }

        public void Counter_CheckIfCounterIsRightWhenAddingDrivers()
        {
            UnitCar car = new UnitCar("VW", 100, 100);
            UnitDriver driver = new UnitDriver("Daniel", car);

            int equalTo = 1;

            race.AddDriver(driver);

            Assert.That(race.Counter, Is.EqualTo(equalTo));
        }

        [Test]
        public void AddDriver_CheckIfAddingDriverWorksProperly()
        {
            UnitCar car = new UnitCar("VW", 100, 100);
            UnitDriver driver = new UnitDriver("Daniel", car);

            race.AddDriver(driver);

            int equalTo = race.Counter;

            Assert.That(race.Counter, Is.EqualTo(equalTo));
        }

        [Test]
        public void AddDriver_CheckIfCatchesExceptionWhenDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(null));
        }

        [Test]
        public void AddDriver_CheckIfCatchesExceptionWhenAddingExistingDriver()
        {
            string driverName = "Daniel";

            race.AddDriver(new UnitDriver(driverName, new UnitCar("Tesla", 100, 300)));

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(new UnitDriver(driverName, new UnitCar("VW", 100, 100))));
        }

        [Test]
        public void AddDriver_ReturnCorrectMessage()
        {
            string name = "Daniel";
            string receivedMessage = race.AddDriver(new UnitDriver(name, new UnitCar("VW", 100, 200)));
            string equalMessage = $"Driver {name} added in race.";

            Assert.That(receivedMessage, Is.EqualTo(equalMessage));
        }

        [Test]
        public void CalculateAverageHorsePower_CheckIfCalculatesAverageHorsePower()
        {
            UnitCar car = new UnitCar("VW", 100, 100);
            UnitDriver driver = new UnitDriver("Daniel", car);

            double expected = 0;

            for (int i = 0; i < 5; i++)
            {
                int hp = 400 + i;
                expected += hp;

                race.AddDriver(new UnitDriver($"Name-{i}", new UnitCar($"Model-{i}", hp, 150)));
            }

            expected /= race.Counter;

            Assert.That(race.CalculateAverageHorsePower(), Is.EqualTo(expected));
        }

        [Test]
        public void CalculateAverageHorsePower_CheckIfMethodCatchException()
        {
            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }
    }
}