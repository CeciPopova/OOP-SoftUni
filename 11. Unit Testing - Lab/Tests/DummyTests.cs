using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void ShouldDummyLoosesHealthIfAttacked()
        {
            Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(1);
            Assert.That(dummy.Health, Is.EqualTo(9));
        }
        [Test]
        public void ShouldDeadDummyThrowAnExceptionIfAttacked()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(1));
        }
        [Test]
        public void ShouldDeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.That(() => dummy.GiveExperience(), Is.EqualTo(10));
        }
        [Test]
        public void ShouldAliveDummyCantGiveXP()
        {
            Dummy dummy = new Dummy(10, 10);
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}