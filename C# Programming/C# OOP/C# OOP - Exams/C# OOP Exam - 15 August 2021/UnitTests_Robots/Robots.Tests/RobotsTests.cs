namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        private RobotManager manager;
        [SetUp]
        public void Setup()
        {
            manager = null;
        }

        [Test]
        public void Ctor_CheckIfCreatesAValidInstance()
        {
            int capacity = 10;

            manager = new RobotManager(capacity);

            Assert.That(manager.Capacity, Is.EqualTo(capacity));
            Assert.That(manager.Count, Is.Zero);
        }

        [Test]
        public void Ctor_ThrowExceptionWhenGivenNegativeCapacity()
        {
            int capacity = -5;

            Assert.Throws<ArgumentException>(() => manager = new RobotManager(capacity));
        }

        [Test]
        public void Add_ThrowExceptionIfRobotExists()
        {
            int capacity = 10;

            manager = new RobotManager(capacity);

            Robot robot = new Robot("Daniel", 50);

            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => manager.Add(robot));
        }

        [Test]
        public void Add_ThrowExceptionIfCapacityIsExceeded()
        {
            int capacity = 1;

            manager = new RobotManager(capacity);

            Robot robot = new Robot("Daniel", 50); 
            Robot robotTwo = new Robot("Natalie", 50);

            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => manager.Add(robotTwo));
        }

        [Test]
        public void Add_CheckIfAddsRobotCorrectly()
        {
            int capacity = 1;
            Robot robot = new Robot("Daniel", 50);

            manager = new RobotManager(capacity);
            manager.Add(robot);

            Assert.That(manager.Count, Is.EqualTo(capacity));
        }

        [Test]
        public void Remove_ThrowExceptionIfRobotDoesNotExists()
        {
            manager = new RobotManager(1);

            Assert.Throws<InvalidOperationException>(() => manager.Remove("Daniel"));
        }

        [Test]
        public void Remove_CheckIfRemovesTheRobotCorrectly()
        {
            manager = new RobotManager(1);

            manager.Add(new Robot("Daniel", 50));

            manager.Remove("Daniel");

            Assert.That(manager.Count, Is.Zero);
        }

        [Test]
        public void Work_ThrowExceptionIfRobotDoesNotExist()
        {
            manager = new RobotManager(1);

            Assert.Throws<InvalidOperationException>(() => manager.Work("Daniel", "Job", 10));
        }

        [Test]
        public void Work_ThrowExceptionIfBatteryIsNotEnough()
        {
            manager = new RobotManager(1);

            manager.Add(new Robot("Daniel", 10));

            Assert.Throws<InvalidOperationException>(() => manager.Work("Daniel", "Job", 20));
        }

        [Test]
        public void Work_CheckIfCorrectlyDecreaseBatteryValue()
        {
            Robot robot = new Robot("Daniel", 10);
            manager = new RobotManager(1);

            manager.Add(robot);
            manager.Work("Daniel", "Job", 10);

            Assert.That(robot.Battery, Is.Zero);
        }

        [Test]
        public void Charge_CheckIfRechargesBattery()
        {
            Robot robot = new Robot("Daniel", 10);
            manager = new RobotManager(1);

            manager.Add(robot);
            manager.Work("Daniel", "Job", 5);
            manager.Charge("Daniel");

            Assert.That(robot.Battery, Is.EqualTo(10));
        }
    }
}
