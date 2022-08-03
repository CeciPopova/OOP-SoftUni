namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            this.arena = new Arena();
        }
        [Test]
        public void TestConstructorInitializesEmptyCollectionOfWarriors()
        {
            Arena testArena = new Arena();

            List<Warrior> warriors = testArena.Warriors.ToList();
            List<Warrior> expectedCollection = new List<Warrior>();
            CollectionAssert.AreEqual(expectedCollection, warriors);
        }
        [Test]
        public void TestCountReturnCorrectData()
        {
            Warrior warrior = new Warrior("Victor", 50, 100);
            this.arena.Enroll(warrior);
            int actualCount = this.arena.Count;
            int expectedCount = 1;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void CountShouldReturnZeroOnEmptyArena()
        {
            int actualCount = this.arena.Count;
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, actualCount);

        }
        [Test]
        public void TestEnrollAddsWarriorsToTheArena()
        {
            Warrior victor = new Warrior("Victor", 30, 100);
            Warrior slav = new Warrior("Slav", 35, 85);

            this.arena.Enroll(victor);
            this.arena.Enroll(slav);

            List<Warrior> actualWarriors = this.arena.Warriors.ToList();
            List<Warrior> expectedWarriors = new List<Warrior>()
            {
                victor,
                slav
            };

            CollectionAssert.AreEqual(expectedWarriors, actualWarriors);
        }
        [Test]
        public void EnrollShouldTrowExceptionWhenWarriorExistInArena()
        {
            Warrior warrior = new Warrior("Victor", 50, 100);
            this.arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior);
            }, "Warrior is already enrolled for the fights!");
        }
        [Test]
        public void FighthBetweenInExistingAttackerShouldTrowException()
        {
            Warrior warrior = new Warrior("Victor", 50, 100);
            this.arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight("Invalid", "Victor");
            }, "There is no fighter with name Invalid enrolled for the fights!");
        }
        [Test]
        public void FighthBetweenInExistingDeffenderShouldTrowException()
        {
            Warrior warrior = new Warrior("Victor", 50, 100);
            this.arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight("Victor", "Invalid");
            }, "There is no fighter with name Invalid enrolled for the fights!");
        }
        [Test]
        public void FighthExcistingWarriorsShouldSuccseed()
        {
            Warrior warriorA = new Warrior("Victor", 40, 100);
            Warrior warriorD = new Warrior("Slav", 55, 100);
            this.arena.Enroll(warriorA);
            this.arena.Enroll(warriorD);

            this.arena.Fight("Victor", "Slav");
            int actualAttackerHp = warriorA.HP;
            int expectedAttackerHp = 100 - warriorD.Damage;

            int actualDefenderHp = warriorD.HP;
            int expectedDeffenderHp = 100 - warriorA.Damage;

            Assert.AreEqual(expectedAttackerHp, actualAttackerHp);
            Assert.AreEqual(expectedDeffenderHp, actualDefenderHp);
        }
    }
}
