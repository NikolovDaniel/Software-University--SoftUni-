using NUnit.Framework;
using System;

public class WarriorTests
{

    private Warrior warrior;
    private Warrior target;

    [SetUp]
    public void Initialize()
    {
        target = new Warrior("Daniel", 50, 100);
    }

    [Test]
    [TestCase(40, 100, 35, 100)]
    [TestCase(50, 100, 35, 50)]
    [TestCase(60, 100, 35, 50)]
    [TestCase(50, 100, 100, 50)]
    public void Attack_DecreaseWarriorsHealth(int attackerDmg, int attackerHp, int targetDmg, int targetHp)
    {
        Warrior attacker = new Warrior("Pesho", attackerDmg, attackerHp);
        Warrior target = new Warrior("Daniel", targetDmg, targetHp);

        int attackerExpectedHp = attacker.HP - target.Damage;
        int targetExpectedHp = target.HP - attacker.Damage;

        if (targetExpectedHp < 0) targetExpectedHp = 0;

        attacker.Attack(target);

        Assert.That(attacker.HP, Is.EqualTo(attackerExpectedHp));
        Assert.That(target.HP, Is.EqualTo(targetExpectedHp));
    }

    [Test]
    [TestCase(30)]
    [TestCase(15)]
    [TestCase(0)]
    public void Attack_ThrowExceptionWhenTargetHpIsLow(int hp)
    {
        Warrior attacker = new Warrior("Pesho", 10, 50);
        Warrior target = new Warrior("Daniel", 50, hp);

        Assert.Throws<InvalidOperationException>(() => attacker.Attack(target));
    }

    [Test]
    [TestCase(35)]
    [TestCase(30)]
    [TestCase(25)]
    public void Attack_ThrowExceptionWhenDataIsInvalid(int hp)
    {
        Warrior attacker = new Warrior("Pesho", 10, hp);
        Warrior target = new Warrior("Daniel", 50, 50);

        Assert.Throws<InvalidOperationException>(() => attacker.Attack(target));
    }

    [Test]
    [TestCase(null, 100, 100)]
    [TestCase("", 100, 100)]
    [TestCase("null", 0, 100)]
    [TestCase("null", -10, 100)]
    [TestCase("null", 100, -100)]
    public void Ctor_ThrowsExceptionWhenDataIsInvalid(string name, int damage, int hp)
    {
        Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
    }
}
