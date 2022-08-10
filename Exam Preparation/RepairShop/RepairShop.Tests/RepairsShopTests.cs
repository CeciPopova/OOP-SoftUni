using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void GarageNameShouldThrowExceptionWithEmptyAndNullValues()
            {

                Assert.Throws<ArgumentNullException>(() =>
                {
                    var garage = new Garage(null, 20);
                }, "Invalid garage name.");
                Assert.Throws<ArgumentNullException>(() =>
                {
                    var garage = new Garage(String.Empty, 20);
                }, "Invalid garage name.");

            }
            [Test]
            public void GarageNanePropertyShouldWorkCorrectly()
            {
                var garage = new Garage("Test", 10);
                string expectedNameGarage = "Test";
                string actualGarageName = garage.Name;
                Assert.AreEqual(expectedNameGarage, actualGarageName);
            }
            [Test]
            public void GarageMechanicsShouldThrowExceptionWithNoMechanics()
            {

                Assert.Throws<ArgumentException>(() =>
                {
                    var garage = new Garage("Test", -7);
                }, "At least one mechanic must work in the garage.");
                Assert.Throws<ArgumentException>(() =>
                {
                    var garage = new Garage("Test", 0);
                }, "At least one mechanic must work in the garage.");

            }
            [Test]
            public void GarageMechanicPropertyShouldWorkCorrectly()
            {
                var garage = new Garage("Test", 10);
                int expectedGarageMechanics = 10;
                int actualGarageMechanics = garage.MechanicsAvailable;
                Assert.AreEqual(expectedGarageMechanics, actualGarageMechanics);
            }
            [Test]
            public void GarageAddCarShouldThrowExceptionWithNoAvailableMechanics()
            {
                var garage = new Garage("Test", 1);
                var firstCar = new Car("Sitroen", 10);
                var secondCar = new Car("Opel", 7);
                garage.AddCar(firstCar);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(secondCar);
                }, "No mechanic available.");
            }
            [Test]
            public void CarsInGarageShouldReturnTheCarsCount()
            {
                var garage = new Garage("Test", 26);
                var firstCar = new Car("Sitroen", 10);
                var secondCar = new Car("Opel", 7);
                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                int expectedCount = 2;
                int actualCount = garage.CarsInGarage;
                Assert.AreEqual(expectedCount, actualCount);
            }
            [Test]
            public void FixCarShouldTrowExceptionWhenTheCarModelNotExists()
            {
                var cars = new List<Car>();
                var garage = new Garage("Test", 10);
                var firstCar = new Car("Sitroen", 1);
                var secondCar = new Car("Opel", 2);
                var thirdCar = new Car("BMW", 3);
                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar(thirdCar.CarModel);
                }, $"The car {thirdCar.CarModel} doesn't exist.");

            }
            [Test]
            public void FixCarMethodShouldRepairTheCarIssues()
            {
                var garage = new Garage("Test", 10);
                var firstCar = new Car("Sitroen", 2);
                var secondCar = new Car("Opel", 2);
                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                garage.FixCar(firstCar.CarModel);
                int expectedIssues = 0;
                int actualIssues = firstCar.NumberOfIssues;
                Assert.AreEqual(expectedIssues, actualIssues);
            }
            [Test]
            public void MethodRemoveFixedCarShouldRemoveTheCarFromTheGarage()
            {
                var garage = new Garage("Test", 10);
                var firstCar = new Car("Sitroen", 2);
                var secondCar = new Car("Opel", 2);
                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                garage.FixCar(firstCar.CarModel);
                int expectedCount = 1;
                int carsToRemoveCount = garage.RemoveFixedCar();
                Assert.AreEqual(expectedCount, carsToRemoveCount);
            }
            [Test]
            public void MethodRemoveFixedCarShouldThrowExceptionWhenNoCarAvailable()
            {
                var garage = new Garage("Test", 10);
                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar(), "No fixed cars available.");
            }
            [Test]
            public void MethodReportShouldReturnAllCarThatIsNotFixed()
            {
                var garage = new Garage("Test", 10);
                var firstCar = new Car("Sitroen", 2);
                var secondCar = new Car("Opel", 2);
                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                garage.FixCar(firstCar.CarModel);
                string expectedReport = "There are 1 which are not fixed: Opel.";
                string actualReport = garage.Report();
                Assert.AreEqual(expectedReport, actualReport);
            }
        }
    }
}