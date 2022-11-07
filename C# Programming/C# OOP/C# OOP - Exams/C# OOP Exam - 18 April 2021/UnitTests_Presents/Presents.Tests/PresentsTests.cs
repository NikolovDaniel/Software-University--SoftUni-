namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {

        private Bag bag;

        [SetUp]
        public void Setup()
        {
            bag = new Bag();
        }

        [Test]
        public void Ctor_CheckIfCreatesInstanceCorrectly()
        {
            Assert.That(bag.GetPresents().Count, Is.Zero);
        }

        [Test]
        public void Create_CheckIfReturnsCorrectString()
        {
            Present present = new Present("Daniel", 15.5);

            string expected = $"Successfully added present {present.Name}.";

            string output = bag.Create(present);

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void Create_ThrowExceptionIfPresentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }

        [Test]
        public void Create_ThrowExceptionIfPresentExists()
        {
            Present present = new Present("Daniel", 15.5);
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void Create_CheckIfCreatesAPresentCorrectly()
        {
            Present present = new Present("Daniel", 15.5);
            bag.Create(present);

            Assert.That(bag.GetPresents().Count, Is.EqualTo(1));
        }

        [Test]
        public void Remove_CheckIfRemovesThePresent()
        {
            Present present = new Present("Daniel", 15.5);
            bag.Create(present);

            bool expected = true;
            bool usual = bag.Remove(present);

            Assert.That(usual, Is.EqualTo(expected));
        }

        [Test]
        public void GetPresent_CheckIfGetsTheCorrectPresent()
        {
            Present present = new Present("Daniel", 15.5);
            bag.Create(present);

            Assert.That(bag.GetPresent("Daniel"), Is.EqualTo(present));
        }

        //TRUE
        [Test]
        public void GetPresentWithLeastMagic_CheckIfGetsTheCorrectPresent()
        {
            Present present = new Present("Daniel", 15.5);
            Present presentTwo = new Present("Ivan", 40);

            bag.Create(present);
            bag.Create(presentTwo);

            Assert.That(bag.GetPresentWithLeastMagic(), Is.EqualTo(present));
        }
    }
}
