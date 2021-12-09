namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;

        [SetUp]
        public void Setup()
        {
            aquarium = null;
        }

        [Test]
        public void Ctor_CheckIfCreateACorrectAquarium()
        {
            string name = "Daniel";
            int capacity = 10;

            aquarium = new Aquarium(name, capacity);

            Assert.That(aquarium.Name == name && aquarium.Capacity == capacity);
            Assert.That(aquarium.Count, Is.Zero);
        }

        [Test]
        public void Ctor_ThrowExceptionWhenGivenInvalidCapacity()
        {
            string name = "Daniel";
            int capacity = -5;

            Assert.Throws<ArgumentException>(() => aquarium = new Aquarium(name, capacity));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Ctor_ThrowExceptionWhenNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium(name, 10));
        }

        [Test]
        public void Add_CheckIfAddsFishCorrectly()
        {
            aquarium = new Aquarium("Daniel", 10);

            Fish fish = new Fish("Kris");

            aquarium.Add(fish);

            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_ThrowExceptionWhenCapacityIsExceeded()
        {
            aquarium = new Aquarium("Daniel", 1);

            Fish fish = new Fish("Kris");
            Fish fishTwo = new Fish("Iva");

            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fishTwo));
        }

        [Test]
        public void RemoveFish_CheckIfRemovesFish()
        {
            string name = "Kris";

            aquarium = new Aquarium("Daniel", 1);

            Fish fish = new Fish("Kris");

            aquarium.Add(fish);

            aquarium.RemoveFish(name);

            Assert.That(aquarium.Count, Is.Zero);
        }

        [Test]
        public void RemoveFish_ThrowExceptionWhenFishIsNull()
        {
            string name = "Kris";

            aquarium = new Aquarium("Daniel", 1);

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(name));
        }

        [Test]
        public void SellFish_CheckIfSellsFishCorrectly()
        {
            string name = "Kris";

            aquarium = new Aquarium("Daniel", 1);

            Fish fish = new Fish(name);

            aquarium.Add(fish);

            Fish expectedFish = null;

            Assert.That(() => expectedFish = aquarium.SellFish(name), Is.EqualTo(fish));
        }

        [Test]
        public void SellFish_ThrowExceptionWhenRequstedFishIsNotFound()
        {
            string name = "Kris";

            aquarium = new Aquarium("Daniel", 1);

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(name));
        }

        [Test]
        public void Report_CheckIfReturnsCorrectString()
        {
            aquarium = new Aquarium("Daniel", 5);
            List<Fish> fishes = new List<Fish>();

            for (int i = 0; i < 5; i++)
            {
                aquarium.Add(new Fish($"Kris-{i}"));
                fishes.Add(new Fish($"Kris-{i}"));
            }

            string names = string.Join(", ", fishes.Select(x => x.Name));
            string expectedOutput = $"Fish available at {aquarium.Name}: {names}";

            Assert.That(expectedOutput, Is.EqualTo(aquarium.Report()));
        }
    }
}
