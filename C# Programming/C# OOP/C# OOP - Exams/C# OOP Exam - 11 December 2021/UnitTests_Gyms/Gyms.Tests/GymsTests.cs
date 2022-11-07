using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        private Gym gym;

        [SetUp]
        public void Setup()
        {
            gym = null;
        }

        [Test]
        public void Ctor_ThrowExceptionWhenGivenInvalidName() // CORRECT
        {
            Assert.Throws<ArgumentNullException>(() => gym = new Gym(null, 15));
        }

        [Test]
        public void Ctor_ThrowExceptionWhenGivenInvalidCapacity() // CORRECT 
        {
            Assert.Throws<ArgumentException>(() => gym = new Gym("Daniel", -5));
        }

        [Test]
        public void Ctor_CheckIfCreatesAnInstanceCorrectly() // CORRECT
        {
            string name = "Daniel";
            int capacity = 10;

            gym = new Gym(name, capacity);

            Assert.That(gym.Name, Is.EqualTo(name));
        }

        [Test]
        public void AddAthlete_ThrowExceptionIfCapacityIsExceeded() // CORRECT
        {
            gym = new Gym("Daniel", 1);

            Athlete athlete = new Athlete("DanielNikolov");

            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("Ivan")));
        }

        [Test]
        public void AddAthlete_CheckIfAddsAnAthlete() // CORRECT
        {
            gym = new Gym("Daniel", 1);

            Athlete athlete = new Athlete("DanielNikolov");
            gym.AddAthlete(athlete);

            Assert.That(gym.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveAthlete_ThrowExceptionIfAthleteIsNull()
        {
            gym = new Gym("Daniel", 1);
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Daniel"));
        }

        [Test]
        public void RemoveAthlete_CheckIfRemovesAnAthleteCorrectly()
        {
            gym = new Gym("Daniel", 1);

            Athlete athlete = new Athlete("DanielNikolov");

            gym.AddAthlete(athlete);
            gym.RemoveAthlete("DanielNikolov");

            Assert.That(gym.Count, Is.Zero);
        }

        [Test]
        public void InjureAthlete_ThrowExceptionIfAthleteIsNull()
        {
            gym = new Gym("Daniel", 1);
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Daniel"));
        }

        [Test]
        public void InjureAthlete_CheckIfMakesTheAthleteInjured()
        {
            gym = new Gym("Daniel", 1);

            Athlete athlete = new Athlete("DanielNikolov");

            gym.AddAthlete(athlete);
            gym.InjureAthlete("DanielNikolov");

            Assert.That(athlete.IsInjured, Is.True);
        }

        [Test]
        public void InjuredAthlete_CheckIfReturnsCorrectAthlete()
        {
            gym = new Gym("Daniel", 3);

            Athlete athlete = new Athlete("DanielNikolov");

            gym.AddAthlete(athlete);

            Athlete outputAthlete = gym.InjureAthlete("DanielNikolov");

            Assert.That(outputAthlete, Is.EqualTo(athlete));
        }

        [Test]
        public void Report_CheckIfReturnsCorrectString()
        {
            gym = new Gym("Daniel", 10);
            List<string> names = new List<string>();

            for (int i = 0; i < 5; i++)
            {
                gym.AddAthlete(new Athlete($"Daniel-{i}"));
                names.Add($"Daniel-{i}");
            }

            string athNames = $"{string.Join(", ", names)}";
            string expectedOutput = $"Active athletes at {gym.Name}: {athNames}";
            string output = gym.Report();

            Assert.That(output, Is.EqualTo(expectedOutput));
        }
    }
}
