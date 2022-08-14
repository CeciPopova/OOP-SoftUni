using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {

        [Test]
        public void CapacityShouldThrowExceptionWhenItsValueIsLessThenZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(-7);
            }, "Invalid capacity.");

        }
        [Test]
        public void CapacityShouldWorkCorrectly()
        {
            Shop shop = new Shop(777);
            int expectedCapacity = 777;
            int actualCapacity = shop.Capacity;
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        [Test]
        public void MethodAddAddsSmartfonesToTheShop()
        {
            Smartphone smartphoneOne = new Smartphone("AppleIPhone13", 5);
            Smartphone smartphoneTwo = new Smartphone("AppleIPhone11", 7);

            Shop shop = new Shop(7);
            shop.Add(smartphoneOne);
            shop.Add(smartphoneTwo);
            int expectedCount = 2;
            int actualCount = shop.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]

        public void MethodAddThrowExceptionWhenCountIsEqualToShopCapacity()
        {

            Smartphone smartphoneOne = new Smartphone("AppleIPhone13", 5);
            Smartphone smartphoneTwo = new Smartphone("AppleIPhone11", 7);
            Smartphone smartphoneThree = new Smartphone("AppleIPhone10", 8);


            Shop shop = new Shop(2);
            shop.Add(smartphoneTwo);
            shop.Add(smartphoneOne);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphoneThree);
            }, "The shop is full.");
        }
        [Test]
        public void MethodAddTrowsExceptionWhenTheModelIsExistInTheShop()
        {
            Smartphone smartphoneOne = new Smartphone("AppleIPhone13", 5);
            Smartphone smartphoneTwo = new Smartphone("AppleIPhone11", 7);


            Shop shop = new Shop(7);
            shop.Add(smartphoneTwo);
            shop.Add(smartphoneOne);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("AppleIPhone13", 77));
            }, "The phone model AppleIPhone13 already exist.");
        }
        [Test]
        public void RemoveMethodWorksCorrectly()
        {
            Smartphone smartphoneOne = new Smartphone("AppleIPhone13", 5);
            Smartphone smartphoneTwo = new Smartphone("AppleIPhone11", 7);
            Smartphone smartphoneThree = new Smartphone("AppleIPhone10", 8);


            Shop shop = new Shop(7);
            shop.Add(smartphoneTwo);
            shop.Add(smartphoneOne);
            shop.Add(smartphoneThree);
            shop.Remove(smartphoneOne.ModelName);

            int expectedCount = 2;
            int actualCount = shop.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void RemoveMethodShouldThrowExceptionWhenThePhoneModelIsNotExist()
        {
            Smartphone smartphoneOne = new Smartphone("AppleIPhone13", 5);
            Smartphone smartphoneTwo = new Smartphone("AppleIPhone11", 7);
            Smartphone smartphoneThree = new Smartphone("AppleIPhone10", 8);


            Shop shop = new Shop(7);
            shop.Add(smartphoneTwo);
            shop.Add(smartphoneOne);
            shop.Add(smartphoneThree);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("Nokia7");
            }, "The phone model Nokia7 doesn't exist.");

        }
        [Test]
        public void MethodTestPhoneShouldDecreaseThePhoneCurrentBatteryCharge()
        {
            Smartphone smartphoneOne = new Smartphone("AppleIPhone13", 5);
            Smartphone smartphoneTwo = new Smartphone("AppleIPhone11", 7);
            Smartphone smartphoneThree = new Smartphone("AppleIPhone10", 8);

            Shop shop = new Shop(7);
            shop.Add(smartphoneTwo);
            shop.Add(smartphoneOne);
            shop.Add(smartphoneThree);
            shop.TestPhone("AppleIPhone13", 2);
            int expectedBattery = 3;
            int actualBattery = smartphoneOne.CurrentBateryCharge;
            Assert.AreEqual(expectedBattery, actualBattery);
        }
        [Test]
        public void MethodTestPhoneShouldThrowExceptionWhenThePhoneIsNotExist()
        {
            Smartphone smartphoneOne = new Smartphone("AppleIPhone13", 5);
            Smartphone smartphoneTwo = new Smartphone("AppleIPhone11", 7);
            Smartphone smartphoneThree = new Smartphone("AppleIPhone10", 8);

            Shop shop = new Shop(7);
            shop.Add(smartphoneTwo);
            shop.Add(smartphoneOne);
            shop.Add(smartphoneThree);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("AppleIPhone1", 2);
            }, "The phone model AppleIPhone1 doesn't exist.");
        }
        [Test]
        public void MethodTestPhoneShouldThrowExceptionWhenThePhoneBatteryChargeIsLow()
        {
            Smartphone smartphoneOne = new Smartphone("AppleIPhone13", 5);
            Smartphone smartphoneTwo = new Smartphone("AppleIPhone11", 7);
            Smartphone smartphoneThree = new Smartphone("AppleIPhone10", 8);

            Shop shop = new Shop(7);
            shop.Add(smartphoneTwo);
            shop.Add(smartphoneOne);
            shop.Add(smartphoneThree);
            shop.TestPhone("AppleIPhone13", 3);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("AppleIPhone13", 3);
            }, "The phone model AppleIPhone13 is low on batery.");
        }
        [Test]
        public void MethodChargePhoneShouldThrowExceptionWhenThePhoneIsNotExist()
        {
            Smartphone smartphoneOne = new Smartphone("AppleIPhone13", 5);
            Smartphone smartphoneTwo = new Smartphone("AppleIPhone11", 7);
            Smartphone smartphoneThree = new Smartphone("AppleIPhone10", 8);

            Shop shop = new Shop(7);
            shop.Add(smartphoneTwo);
            shop.Add(smartphoneOne);
            shop.Add(smartphoneThree);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("AppleIPhone1");
            }, "The phone model AppleIPhone1 doesn't exist.");
        }
        [Test]
        public void MethodChargePhoneShouldChargingCurrantPhoneToMaximumBatteryCharge()
        {
            Smartphone smartphoneOne = new Smartphone("AppleIPhone13", 5);
            Smartphone smartphoneTwo = new Smartphone("AppleIPhone11", 7);
            Smartphone smartphoneThree = new Smartphone("AppleIPhone10", 8);

            Shop shop = new Shop(7);
            shop.Add(smartphoneTwo);
            shop.Add(smartphoneOne);
            shop.Add(smartphoneThree);
            shop.TestPhone("AppleIPhone13", 2);
            shop.ChargePhone("AppleIPhone13");
            int expectedBattery = 5;
            int actualBattery = smartphoneOne.CurrentBateryCharge;
            Assert.AreEqual(expectedBattery, actualBattery);
        }


    }
}