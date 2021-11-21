using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        private const int valueToCheck = 1;
        [SetUp] 
        public void Initialize()
        {
            axe = new Axe(10, 2);
            dummy = new Dummy(15, 15);
        }
        [Test]
        public void CheckIfWeaponLosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(valueToCheck), "Durability not decreased after attack!");
        }

        [Test]
        public void CheckIfItIsPossibleToAttackWithBrokenWeapon()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.That(() => axe.Attack(dummy),
                Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."),
                "Can attack with broken weapon!");
        }
    }
}