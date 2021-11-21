using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Axe axe;
        private Dummy aliveTarget;
        private Dummy deadTarget;
        private const int valueToUse = 5;
        [SetUp]
        public void Initialize()
        {
            axe = new Axe(5, 5);
            aliveTarget = new Dummy(10, 10);
            deadTarget = new Dummy(0, 5);
        }
        [Test]
        public void DummyLosesHealthWhenAttacked()
        {
            axe.Attack(aliveTarget);

            Assert.That(aliveTarget.Health, Is.EqualTo(valueToUse), "Dummy does not lose health when attacked!");
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            Assert.That(() => axe.Attack(deadTarget),
                Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."),
                "Dead dummy can be attacked!");
        }
        [Test]
        public void DeadDummyCanGiveExperience()
        {
            int experience = deadTarget.GiveExperience();

            Assert.That(experience, Is.EqualTo(valueToUse), "Dummy does not give experience when dead!");
        }
        [Test]
        public void AliveDummyCanNotGiveExperience()
        {
            Assert.That(() => aliveTarget.GiveExperience(),
                Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."),
                "Dummy gives experience while alive!");
        }
    }
}