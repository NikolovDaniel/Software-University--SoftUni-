using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {
        private ComputerManager computers;
        [SetUp]
        public void Setup()
        {
            computers = new ComputerManager();
        }

        [Test]
        public void Ctor_CheckIfCtorWorksProperly()
        {
            Assert.That(computers.Count, Is.Zero);
        }

        [Test]
        public void AddComputer_ThrowExceptionNullValue()
        {
            Assert.Throws<ArgumentNullException>(() => computers.AddComputer(null));
        }
        [Test]
        public void AddComputer_CheckIfComputerIsAddedCorrectly()
        {
            Computer computer = new Computer("Asus", "Huracan", 200);

            computers.AddComputer(computer);

            int expectedLength = computers.Count;

            Assert.That(computers.Count, Is.EqualTo(expectedLength));
        }

        [Test]
        public void AddComputer_ThrowExceptionWhenComputerExists()
        {
            Computer computer = new Computer("Asus", "Huracan", 200);

            computers.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => computers.AddComputer(new Computer("Asus", "Huracan", 200)));
        }

        [Test]
        public void RemoveComputer_CheckIfMethodIsReturningComputer()
        {
            Computer computer = new Computer("Asus", "Huracan", 200);

            computers.AddComputer(computer);

            Computer currComputer = computers.RemoveComputer("Asus", "Huracan");

            Assert.That(currComputer, Is.EqualTo(computer));
        }

        [Test]
        public void RemoveComputer_CheckIfMethodIsRemovingComputer()
        {
            Computer computer = new Computer("Asus", "Huracan", 200);
            Computer computerTwo = new Computer("Asus1", "Huracan1", 2001);

            computers.AddComputer(computer);
            computers.AddComputer(computerTwo);
            computers.RemoveComputer("Asus", "Huracan");

            Assert.That(computers.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetComputer_CheckIfGetsComputer()
        {
            Computer computer = new Computer("Asus", "Huracan", 200);

            computers.AddComputer(computer);

            Computer currComputer = computers.GetComputer("Asus", "Huracan");

            Assert.That(currComputer, Is.EqualTo(computer));
        }

        [Test]
        public void GetComputer_ThrowExceptionIfComputerIsNullWithRemove()
        {
            Assert.Throws<ArgumentException>(() => computers.RemoveComputer("Daniel", "Nikolov"));
        }

        [Test]
        public void GetComputer_ThrowExceptionIfComputerIsNullWithGetComputer()
        {
            Assert.Throws<ArgumentException>(() => computers.GetComputer("Daniel", "Nikolov"));
        }

        [Test]
        public void GetComputer_ThrowExceptionWhenGivenNullManufacturer()
        {
            Assert.Throws<ArgumentNullException>(() => computers.GetComputer(null, "Daniel"));
        }

        [Test]
        public void GetComputer_ThrowExceptionWhenGivenNullModel()
        {
            Assert.Throws<ArgumentNullException>(() => computers.GetComputer("Daniel", null));
        }

        [Test]
        public void GetComputersByManufacturer_ThrowExceptionWhenManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => computers.GetComputersByManufacturer(null));
        }

        [Test]
        public void GetComputersByManufacturer_CheckIfGetsTheRightCollection()
        {
            int n = 5;

            for (int i = 0; i < n; i++)
            {
                computers.AddComputer(new Computer($"Comp", $"{i}", 100 + i));
            }

            ICollection<Computer> newComputerList = computers.GetComputersByManufacturer("Comp");

            Assert.That(newComputerList.Count, Is.EqualTo(5));
        }
    }
}