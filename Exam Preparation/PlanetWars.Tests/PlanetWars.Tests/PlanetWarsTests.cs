using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void WeaponConstructorShouldWorkCorrectly()
            {
                Weapon weapon = new Weapon("Pistol", 2.5, 7);
                Assert.AreEqual("Pistol", weapon.Name);
                Assert.AreEqual(2.5, weapon.Price);
                Assert.AreEqual(7, weapon.DestructionLevel);
            }
            [Test]
            public void WeaponPriceShouldThrowExceptionWhenIsBelowZero()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("Pistol", -2.5, 7);
                }, "Price cannot be negative.");

            }
            [Test]
            public void IncreaseDestructionLevelShouldIncreaseByOne()
            {
                Weapon weapon = new Weapon("Pistol", 2.5, 7);
                weapon.IncreaseDestructionLevel();
                int expectedDestructionLevel = 8;
                int actualDestructionLevel = weapon.DestructionLevel;
                Assert.AreEqual(expectedDestructionLevel, actualDestructionLevel);
            }
            [Test]
            public void MethodIsNuclearSholdWorkCorrectly()
            {
                Weapon weapon = new Weapon("Pistol", 2.5, 17);
                bool expectedDestruction = true;
                bool actualDestruction = weapon.IsNuclear;
                Assert.AreEqual(expectedDestruction, actualDestruction);
            }
            [Test]
            public void PlanetConstructorWorksCorrectly()
            {
                Planet planet = new Planet("Zero", 77.7);
                Assert.AreEqual("Zero", planet.Name);
                Assert.AreEqual(77.7, planet.Budget);
                int expectedWeaponsCount = 0;
                int actualWeaponsCount = planet.Weapons.Count;
                Assert.AreEqual(expectedWeaponsCount, actualWeaponsCount);

            }
            [Test]
            public void PlanetNameShouldThrowExceptionWhenTheStringIsNullOrWhiteSpace()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(null, 77.7);
                }, "Invalid planet Name");

                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("", 77.7);
                }, "Invalid planet Name");

            }
            [Test]
            public void PlanetNameShouldThrowExceptionWhenTheBudgetIsBelowZero()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("Zero", -7.7);
                }, "Budget cannot drop below Zero!");


            }
            [Test]
            public void MilitaryPowersRatioSholdReturnSumOfWeaponsDestructionLevels()
            {
                Weapon weaponOne = new Weapon("Pistol1", 2.5, 7);
                Weapon weaponTwo = new Weapon("Pistol2", 2.5, 7);
                Planet planet = new Planet("Zero", 77.7);
                planet.AddWeapon(weaponOne);
                planet.AddWeapon(weaponTwo);
                double expectedPower = 14;
                double actualPower = planet.MilitaryPowerRatio;
                Assert.AreEqual(expectedPower, actualPower);
            }
            [Test]
            public void MethodProfitShouldIncreasePlanetBudget()
            {
                Planet planet = new Planet("Zero", 77.7);
                planet.Profit(22.3);
                double expectedBudjet = 100;
                double actualBudget = planet.Budget;
                Assert.AreEqual(expectedBudjet, actualBudget);
            }
            [Test]
            public void MethodSpendFundsShouldDecreaceBudget()
            {
                Planet planet = new Planet("Zero", 77.7);
                planet.SpendFunds(7.7);
                double expectedBudjet = 70;
                double actualBudget = planet.Budget;
                Assert.AreEqual(expectedBudjet, actualBudget);
            }
            [Test]
            public void MethodSpendFundsShouldThrowsExceptionWhenAmountIsMoreThanBudget()
            {
                Planet planet = new Planet("Zero", 77.7);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(100);
                }, "Not enough funds to finalize the deal.");
            }
            [Test]
            public void AddWeaponShouldThrowExceptionWhenTheWeaponAlreadyExists()
            {
                Planet planet = new Planet("Zero", 77.7);
                Weapon weapon = new Weapon("Pistol", 2.5, 7);
                planet.AddWeapon(weapon);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon);
                });
            }
            [Test]
            public void RemoveWeaponMethodShouldRemoveWeaponIfExists()
            {
                Planet planet = new Planet("Zero", 77.7);
                Weapon weaponOne = new Weapon("Pistol1", 2.5, 7);
                Weapon weaponTwo = new Weapon("Pistol2", 2.5, 7);
                planet.AddWeapon(weaponOne);
                planet.AddWeapon(weaponTwo);
                planet.RemoveWeapon("Pistol1");
                int expectedCount = 1;
                int actualCount = planet.Weapons.Count;
                Assert.AreEqual(expectedCount, actualCount);
            }
            [Test]
            public void UpgradeWeaponShouldIncreaseWeaponDestructionLevel()
            {

                Planet planet = new Planet("Zero", 77.7);
                Weapon weapon = new Weapon("Pistol", 2.5, 7);
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("Pistol");
                int expectedDistructonLevel = 8;
                int actualDistructonLevel = weapon.DestructionLevel;
                Assert.AreEqual(expectedDistructonLevel, actualDistructonLevel);
            }
            [Test]
            public void UpgradeWeaponShouldThrowExceptionWhenTheWeaponNameIsNotExist()
            {
                Planet planet = new Planet("Zero", 77.7);
                Weapon weapon = new Weapon("Pistol", 2.5, 7);
                planet.AddWeapon(weapon);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("Pistol2");
                });
            }
            [Test]
            public void DestructOponentShouldThrowExceptionWhenOpponentPowerIsBigger()
            {
                Planet planetA = new Planet("Alfa", 77.7);
                Weapon weaponA = new Weapon("PistolA", 2.5, 5);
                planetA.AddWeapon(weaponA);
                Planet planetZ = new Planet("Zero", 77.7);
                Weapon weaponZ = new Weapon("PistolZ", 2.5, 7);
                planetZ.AddWeapon(weaponZ);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planetA.DestructOpponent(planetZ);
                });
            }
            [Test]
            public void DestructOponentShouldThrowExceptionWhenOpponentPowerIsEqual()
            {
                Planet planetA = new Planet("Alfa", 77.7);
                Weapon weaponA = new Weapon("PistolA", 2.5, 7);
                planetA.AddWeapon(weaponA);
                Planet planetZ = new Planet("Zero", 77.7);
                Weapon weaponZ = new Weapon("PistolZ", 2.5, 7);
                planetZ.AddWeapon(weaponZ);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planetA.DestructOpponent(planetZ);
                });
            }
            [Test]
            public void DestructOponentShouldReturnTheWinner()
            {
                Planet planetA = new Planet("Alfa", 77.7);
                Weapon weaponA = new Weapon("PistolA", 2.5, 9);
                planetA.AddWeapon(weaponA);
                Planet planetZ = new Planet("Zero", 77.7);
                Weapon weaponZ = new Weapon("PistolZ", 2.5, 7);
                planetZ.AddWeapon(weaponZ);
                planetA.DestructOpponent(planetZ);
                string expectedWinner = "Zero is destructed!";
                string actualWinner = planetA.DestructOpponent(planetZ);
                Assert.AreEqual(expectedWinner, actualWinner);
            }
        }
    }
}
