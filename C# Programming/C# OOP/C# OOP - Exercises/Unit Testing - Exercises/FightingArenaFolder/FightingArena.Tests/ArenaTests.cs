using NUnit.Framework;
using System;
using System.Linq;

[TestFixture]
public class ArenaTests
{
    private Warrior warrior;
    private Warrior target;
    private Arena warriors;

    [SetUp]
    public void Initialize()
    {
        warrior = new Warrior("Pesho", 10, 50);
        target = new Warrior("Daniel", 15, 70);
        warriors = new Arena();
    }

    [Test]
    public void Fight_ThrowExceptionWhenDefenderIsNull()
    {
        string nameAttacker = "Pesho";
        string nameDefender = null;

        Assert.Throws<InvalidOperationException>(() => warriors.Fight(nameAttacker, nameDefender));
    }

    [Test]
    public void Fight_ThrowExceptionWhenAttackerIsNull()
    {
        string nameAttacker = null;
        string nameDefender = "Daniel";

        Assert.Throws<InvalidOperationException>(() => warriors.Fight(nameAttacker, nameDefender));
    }

    [Test]
    public void Fight_TestWhenGivenProperWarriors()
    {
        warriors.Enroll(warrior);
        warriors.Enroll(target);

        string nameAttacker = "Pesho";
        string nameDefender = "Daniel";

        warriors.Fight(nameAttacker, nameDefender);

        int expectedHp = 60;

        Assert.That(warriors.Warriors.First(n => n.Name == "Daniel").HP, Is.EqualTo(expectedHp));
    }

    [Test]
    public void Enroll_ThrowExceptionWhenGivenTwoIdenticalWarriors()
    {
        warriors.Enroll(warrior);

        Assert.Throws<InvalidOperationException>(() => warriors.Enroll(new Warrior("Pesho", 10, 50)));
    }

    [Test]
    public void Enroll_TestWhenGivenValidWarrior()
    {
        warriors.Enroll(warrior);
        warriors.Enroll(target);

        int count = 2;

        Assert.That(warriors.Count, Is.EqualTo(count));
    }
}
