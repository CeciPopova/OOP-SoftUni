using NUnit.Framework.Internal;

namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {

        [Test]
        public void FuelAmountConstructor()
        {
            Car car = new Car("Sitroen", "C4", 1.5, 20);
            double expectingFuelAmount = 0;
            double actualFuelAmount = car.FuelAmount;
            Assert.AreEqual(expectingFuelAmount, actualFuelAmount);
        }
        [Test]
        public void ConstructorShouldCreateCarWithCorrectData()
        {
            Car car = new Car("Sitroen", "C4", 1.5, 20);
            string expectedCarMake = "Sitroen";
            string expectedCarModel = "C4";
            double expectedCarFuelConsumption = 1.5;
            double expectedCarFuelCapacity = 20;
            string actualCarMake = car.Make;
            string actualCarModel = car.Model;
            double actualCarFuelConsumption = car.FuelConsumption;
            double actualCarFuelCapacity = car.FuelCapacity;
            Assert.AreEqual(expectedCarMake, actualCarMake);
            Assert.AreEqual(expectedCarModel, actualCarModel);
            Assert.AreEqual(expectedCarFuelConsumption, actualCarFuelConsumption);
            Assert.AreEqual(expectedCarFuelCapacity, actualCarFuelCapacity);
        }


        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void IfMakeIsNullOrEmptyShouldReturnException(string make)
        {

            string model = "C4";
            double fuelConsumption = 1.5;
            double fuelCapacity = 20;
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            }, "Make cannot be null or empty!");
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void IfModelIsNullOrEmptyShouldReturnException(string model)
        {
            string make = "Sitroen";

            double fuelConsumption = 1.5;
            double fuelCapacity = 20;
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            }, "Model cannot be null or empty!");
        }

        [Test]
        public void NegativeFuelConsumptionShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Sitroen", "C4", -1.5, 20);
            }, "Fuel consumption cannot be zero or negative!");
        }



        [Test]
        public void FuelCapacityShouldThrowExceptionWhenIsZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Sitroen", "C4", 1.5, -20);
            }, "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        public void RefuelShouldIncreaseCarFuelAmount()
        {
            Car car = new Car("Sitroen", "C4", 1.5, 20);
            double fuelToRefuel = 5;
            double expectedFuelAmount = car.FuelAmount;
            car.Refuel(fuelToRefuel);

            double actualFuelAmount = car.FuelAmount;
            Assert.AreEqual(expectedFuelAmount + 5, actualFuelAmount);
        }

        [Test]
        public void RefuelMethodShouldReturnAmountEqualToFuelCapacityWhenFuelIsMore()
        {
            Car car = new Car("Sitroen", "C4", 1.5, 20);
            car.Refuel(30);

            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        public void FuelToRefuelShouldNotBeZeroOrNegative()
        {
            Car car = new Car("Sitroen", "C4", 1.5, 20);
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
            }, "Fuel amount cannot be zero or negative!");
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(-6);
            }, "Fuel amount cannot be negative!");
        }
       
        [Test]
        public void MethodDriveShouldDecreaseFuelAmountWithNeededFuel()
        {
            Car car = new Car("Sitroen", "C4", 1.5, 20);
            car.Refuel(20);
            car.Drive(100);
            double expectedFuelAmount = 18.5;
            double actualFuelAmount = car.FuelAmount;
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }
        [Test]
        public void MethodDriveShouldTrowExceptionWhenFuelNeededIsMoreThanFuelAmount()
        {
            Car car = new Car("Sitroen", "C4", 1.5, 20);
            car.Refuel(1);
            Assert.Throws<InvalidOperationException>(() => car.Drive(100), "You don't have enough fuel to drive!");
        }

    }
}