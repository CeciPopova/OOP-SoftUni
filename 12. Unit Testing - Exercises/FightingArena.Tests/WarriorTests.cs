namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedName = "Victor";
            int expectedDamage = 10;
            int expectedHp = 10;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHp);

            string actualName = warrior.Name;
            int actualDamage = warrior.Damage;
            int actualHp = warrior.HP;

            Assert.AreEqual(expectedName, actualName, "Constructor should initialize the Name of the Warior!");
            Assert.AreEqual(expectedDamage, actualDamage, "Constructor should initialize the Damage of the Warior!");
            Assert.AreEqual(expectedHp, actualHp, "Constructor should initialize the HP of the Warior!");
        }
        [Test]
        public void TestNameGetter()
        {
            string expectedName = "Victor";
            Warrior warrior = new Warrior(expectedName, 55, 55);
            string actualName = warrior.Name;
            Assert.AreEqual(expectedName, actualName, "Getter of the property Name should return the value of name!");
        }
        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void TestNameSetterValidator(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 55, 55);
            }, "Name Should not be empty or whitespace");
        }
        [Test]
        public void TestDamageGetter()
        {
            int expectedDamage = 55;
            Warrior warrior = new Warrior("Victor", expectedDamage, 55);
            int actualDamage = warrior.Damage;
            Assert.AreEqual(expectedDamage, actualDamage, "Getter of the property Damage should return the value of damage!");
        }
        [TestCase(-5)]
        [TestCase(0)]
        public void TestDamageSetterValidation(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Victor", damage, 55);
            }, "Damage value should be positive!");
        }
        [Test]
        public void TestHPGetter()
        {
            int expectedHP = 55;
            Warrior warrior = new Warrior("Victor", 33, expectedHP);
            int actualHP = warrior.HP;
            Assert.AreEqual(expectedHP, actualHP, "Getter of the property HP should return the value of hp!");
        }
        [TestCase(-5)]
        public void TestHPSetterValidator(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Victor", 55, hp);

            }, "HP should not be negative!");
        }
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(39)]
        public void AttackShouldThrowErrorWhenAttackingWarriorIsLow(int startHP)
        {
            Warrior warrior = new Warrior("Victor", 70, startHP);
            Warrior strongWarrior = new Warrior("Slav", 55, 45);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(strongWarrior);
            }, "Your HP is too low in order to attack other warriors!");
        }
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(30)]
        public void AttackShouldTrowErrorWhenDeffendingWarriorIsLow(int startHP)
        {
            Warrior warrior = new Warrior("Victor", 55, 55);
            Warrior enemyWarrior = new Warrior("Slav", 35, startHP);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(enemyWarrior);
            }, "Enemy HP must be greater than 30 in order to attack him!");
        }
        [TestCase(50, 60)]
        [TestCase(50, 51)]

        public void AttackShoulwThrowErrorWhenDefenderWarriorIsStronger(int attackerHP, int defenderDamage)
        {
            Warrior warrior = new Warrior("Victor", 50, attackerHP);
            Warrior enemyWarrior = new Warrior("Slav", defenderDamage, 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(enemyWarrior);
            }, "You are trying to attack too strong enemy");
        }
        [TestCase(70, 50)]
        [TestCase(60, 55)]
        [TestCase(55, 55)]
        public void SuccsessAttackShouldDecreaseAttackerHP(int attackerHp, int defenderDamage)
        {
            Warrior warrior = new Warrior("Victor", 50, attackerHp);
            Warrior enemyWarrior = new Warrior("Slav", defenderDamage, 55);
            warrior.Attack(enemyWarrior);
            int actualHp = warrior.HP;
            int expectedHp = attackerHp - defenderDamage;
            Assert.AreEqual(expectedHp, actualHp, "Successful attack should decrease attacker HP!");

        }
        [TestCase(55, 35)]
        public void AttackShouldKillEnemyIfWarriorIsStronger(int damage, int enemyHp)
        {
            Warrior warrior = new Warrior("Victor", damage, 50);
            Warrior enemyWarrior = new Warrior("Slav", 45, enemyHp);
            warrior.Attack(enemyWarrior);
            int expectedHp = 0;
            int actualHp = enemyWarrior.HP;
            Assert.AreEqual(expectedHp, actualHp);
        }
        [TestCase(35, 50)]
        [TestCase(50, 50)]
        public void AttackShouldDecreaseEnemyHpIfIsNotKilled(int damage, int enemyHp)
        {
            Warrior warrior = new Warrior("Victor", damage, 50);
            Warrior enemy = new Warrior("Slav", 35, enemyHp);
            warrior.Attack(enemy);
            int expectedHp = enemy.HP;
            int actualHp = enemyHp - damage;
            Assert.AreEqual(expectedHp, actualHp);
        }
    }
}