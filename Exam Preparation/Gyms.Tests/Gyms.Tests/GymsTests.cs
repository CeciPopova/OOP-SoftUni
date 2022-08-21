using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        // Implement unit tests here
        [Test]
        public void ConstructorAthleteWorksCorrectly()
        {
            Athlete athlete = new Athlete("DanDan");
            string expectedName = "DanDan";
            string actualName = athlete.FullName;
            Assert.AreEqual(expectedName, actualName);
            bool expectedInjured = false;
            bool actualInjured = athlete.IsInjured;
            Assert.AreEqual(expectedInjured, actualInjured);
        }

        [Test]
        public void GymConstructorWorksCorrectly()
        {
            Gym gym = new Gym("Test", 20);
            string expectedName = "Test";
            string actualName = gym.Name;
            Assert.AreEqual(expectedName, actualName);
            int expectedCapacty = 20;
            int actualCapacity = gym.Capacity;
            Assert.AreEqual(expectedCapacty, actualCapacity);
            int expectedCount = 0;
            int actualCount = gym.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void GymNameShouldThrowExceptionIfIsInvalid()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(null, 20);
            });

        }
        [Test]
        public void GymNameShouldThrowExceptionIWhenIsInvalid()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym("", 20);
            });

        }

        [Test]
        public void GymCapacityShouldThrowExceptionIfIsInvalid()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("Test", -20);
            });

        }

        [Test]
        public void MethodAddAthleteShouldThrowExceptionIfCapacityIsFull()
        {
            Gym gym = new Gym("Test", 2);
            Athlete athleteOne = new Athlete("Victor");
            Athlete athleteTwo = new Athlete("Stan");
            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(new Athlete("Mark"));
            });
        }

        [Test]
        public void MethodAddAthleteShouldWorksCorrectly()
        {
            Gym gym = new Gym("Test", 20);
            Athlete athleteOne = new Athlete("Victor");
            Athlete athleteTwo = new Athlete("Stan");
            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            int expectedCount = 2;
            int actualCount = gym.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void MethodRemoveAthleteShouldDecreaseCount()
        {
            Gym gym = new Gym("Test", 20);

            Athlete athleteTwo = new Athlete("Stan");

            gym.AddAthlete(athleteTwo);
            gym.RemoveAthlete("Stan");
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void MethodRemoveAthleteShouldThrowExceptionWhenTheNameIsInvalid()
        {

            Gym gym = new Gym("Test", 20);
            Athlete athleteOne = new Athlete("Victor");
            Athlete athleteTwo = new Athlete("Stan");
            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Dan");
            });
        }
        [Test]
        public void MethodInjureAthleteShouldThrowExceptionWhenTheNameIsInvalid()
        {

            Gym gym = new Gym("Test", 20);
            Athlete athleteOne = new Athlete("Victor");
            Athlete athleteTwo = new Athlete("Stan");
            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Dan");
            });
        }
        [Test]
        public void MethodInjureAthleteShouldWorksCorectly()
        {

            Gym gym = new Gym("Test", 20);
            Athlete athleteOne = new Athlete("Victor");
            Athlete athleteTwo = new Athlete("Stan");
            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            gym.InjureAthlete("Victor");
            Assert.IsTrue(athleteOne.IsInjured);
            Assert.IsFalse(athleteTwo.IsInjured);
        }

        [Test]
        public void InjureAthleteReturnShouldWorkProperly()
        {
            Gym gym = new Gym("Test", 20);

            Athlete athleteOne = new Athlete("Victor");
            Athlete athleteTwo = new Athlete("Stan");
            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);

            Assert.AreEqual(athleteOne, gym.InjureAthlete("Victor"));
        }


        [Test]
        public void MethodReportShouldWorksCorrectly()
        {
            Gym gym = new Gym("Test", 2);
            Athlete athleteOne = new Athlete("Victor");
            Athlete athleteTwo = new Athlete("Stan");
            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            gym.InjureAthlete("Victor");
            string expectedReport = $"Active athletes at Test: Stan";
            string actualReport = gym.Report();
            Assert.AreEqual(expectedReport, actualReport);

        }
    }
}
