using NUnit.Framework;
using System;


public class CarTests
{
    private Car car;

    //[SetUp]
    //public void Setup()
    //{

    //}

    [Test]
    public void Drive_TestWhenFuelIsNotEnough()
    {
        car = new Car("VW", "Polo", 10, 50);

        car.Refuel(4);

        Assert.Throws<InvalidOperationException>(() => car.Drive(50));
    }

    [Test]
    public void Drive_TestWhenFuelIsEnough()
    {
        car = new Car("VW", "Polo", 10, 50);

        car.Refuel(20);

        car.Drive(50);

        Assert.That(car.FuelAmount, Is.EqualTo(15));
    }

    [Test]
    public void Refuel_ThrowExceptionWhenGivenNegativeValue()
    {
        Assert.Throws<ArgumentException>(() => car.Refuel(-1));
    }

    [Test]
    public void Refuel_ThrowExceptionWhenGivenZeroValue()
    {
        Assert.Throws<ArgumentException>(() => car.Refuel(0));
    }
    
    [Test]
    public void Refuel_TestWhenGivenHigherValueThanCapacity()
    {
        car = new Car("VW", "Polo", 10, 50);

        double carRefuel = 70;

        car.Refuel(carRefuel);

        Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
    }

    [Test]
    public void Refuel_TestWhenGivenValidValue()
    {
        car = new Car("VW", "Polo", 10, 50);

        double carRefuel = 30;

        car.Refuel(carRefuel);

        Assert.That(car.FuelAmount, Is.EqualTo(carRefuel));
    }

    [Test]
    public void FuelCapacityProperty_ThrowExceptionWhenGivenNegativeNumber()
    {
        Assert.Throws<ArgumentException>(() => car = new Car("VW", "Polo", 10, -1));
    }

    [Test]
    public void FuelCapacityProperty_ThrowExceptionWhenGivenZeroNumber()
    {
        Assert.Throws<ArgumentException>(() => car = new Car("VW", "Polo", 10, 0));
    }

    [Test]
    public void FuelCapacityProperty_TestWhenGivenProperValue()
    {
        car = new Car("VW", "Polo", 10, 50);

        double fuelCapacity = 50;

        Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
    }

    [Test]
    public void FuelAmountProperty_TestWhenGivenProperValue()
    {
        car = new Car("VW", "Polo", 10, 50);

        double fuelAmount = 0;

        Assert.That(car.FuelAmount, Is.EqualTo(fuelAmount));
    }

    [Test]
    public void FuelConsumptionProperty_ThrowExceptionWhenGivenNegativeNumber()
    {
        Assert.Throws<ArgumentException>(() => car = new Car("VW", "Polo", -1, 50));
    }

    [Test]
    public void FuelConsumptionProperty_ThrowExceptionWhenGivenZeroNumber()
    {
        Assert.Throws<ArgumentException>(() => car = new Car("VW", "Polo", 0, 50));
    }

    [Test]
    public void FuelConsumptionProperty_TestWhenGivenProperValue()
    {
        car = new Car("VW", "Polo", 10, 50);

        double fuelConsumption = 10;

        Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
    }

    [Test]
    public void ModelProperty_ThrowExceptionWhenGivenEmptyString()
    {
        Assert.Throws<ArgumentException>(() => car = new Car("VW", "", 10, 50));
    }

    [Test]
    public void ModelProperty_ThrowExceptionWhenGivenNullString()
    {
        Assert.Throws<ArgumentException>(() => car = new Car("VW", null, 10, 50));
    }

    [Test]
    public void ModelProperty_TestWhenGivenProperInformation()
    {
        car = new Car("VW", "Polo", 10, 50);
        string carModel = "Polo";

        Assert.That(car.Model, Is.EqualTo(carModel));
    }

    [Test]
    public void MakeProperty_ThrowExceptionWhenGivenEmptyString()
    {
        Assert.Throws<ArgumentException>(() => car = new Car("", "Polo", 10, 50));
    }

    [Test]
    public void MakeProperty_ThrowExceptionWhenGivenNullString()
    {
        Assert.Throws<ArgumentException>(() => car = new Car(null, "Polo", 10, 50));
    }
    
    [Test]
    public void MakeProperty_TestWhenGivenProperInformation()
    {
        car = new Car("VW", "Polo", 10, 50);
        string carMake = "VW";

        Assert.That(car.Make, Is.EqualTo(carMake));
    }
}
