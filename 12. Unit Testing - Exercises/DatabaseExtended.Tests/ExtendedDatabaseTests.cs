namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database db;

        [SetUp]
        public void SetUp()
        {
            this.db = new Database();
        }

        [Test]
        public void WhenAddNewPersonCountShouldIncrease()
        {
            Person victor = new Person(12345678, "Victor");
            Person slav = new Person(87654321, "Slav");
            db.Add(victor);
            db.Add(slav);
            int expectingCount = 2;
            int actualCount = this.db.Count;
            Assert.AreEqual(expectingCount, actualCount);
        }
        [Test]
        public void AddingPersonWithExistingNameShouldThrowException()
        {
            Person firstPerson = new Person(12345678, "Victor");
            Person secondPerson = new Person(87654321, "Victor");
            db.Add(firstPerson);
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(secondPerson);
            }, "There is already user with this username!");
        }
        [Test]
        public void AddingPersonWithExistingIdShouldThrowException()
        {
            Person firstPerson = new Person(12345678, "Victor");
            Person secondPerson = new Person(12345678, "Slav");
            db.Add(firstPerson);
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(secondPerson);
            }, "There is already user with this Id!");
        }
        [Test]
        public void AddingMoreThen16PersonsShouldThrowException()
        {
            for (int i = 0; i < 16; i++)
            {
                Person person = new Person(12345678 + i, "Victor" + i);
                db.Add(person);
            }
            Person person1 = new Person(87654321, "Slav");
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(person1);
            }, "Array's capacity must be exactly 16 integers!");
        }
        [Test]
        public void RemovePersonFromEmptyDatabaseShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            });
        }
        [Test]
        public void RemovePersonFromDatabaseShouldDecreaseCount()
        {

            Person victor = new Person(12345678, "Victor");
            Person slav = new Person(87654321, "Slav");
            db.Add(victor);
            db.Add(slav);
            db.Remove();
            int expectingCount = 1;
            int actualCount = this.db.Count;
            Assert.AreEqual(expectingCount, actualCount);

        }
        [Test]
        public void FindPersonByNameWhenTheNameIsEmptyShouldThrowException()
        {
            string name = null;

            for (int i = 0; i < 16; i++)
            {
                Person person = new Person(12345678 + i, "Victor" + i);
                db.Add(person);
            }
            Assert.Throws<ArgumentNullException>(() =>
            {
                db.FindByUsername(name);
            }, "Username parameter is null!");
        }
        [Test]
        public void FindPersonByNameWhenTheNameDontExistShouldThrowException()
        {
            string name = "Slav";

            for (int i = 0; i < 16; i++)
            {
                Person person = new Person(12345678 + i, "Victor" + i);
                db.Add(person);
            }
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername(name);
            }, "No user is present by this username!");
        }
        [Test]
        public void FindPersonByNameShouldReturnPerson()
        {
            string name = "Victor1";

            for (int i = 0; i < 16; i++)
            {
                Person person = new Person(12345678 + i, "Victor" + i);
                db.Add(person);
            }
            Person personToFind = db.FindByUsername(name);
            string personToFindName = personToFind.UserName;
            Assert.AreEqual(name, personToFindName);
        }
        [Test]

        public void FindPersonByIdWhenTheIdIsLessThenZeroShouldThrowException()
        {

            for (int i = 0; i < 16; i++)
            {
                Person person = new Person(12345678 + i, "Victor" + i);
                db.Add(person);
            }
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                db.FindById(-12345678);
            }, "Id should be a positive number!");
        }

        [TestCase(12345678)]
        public void FindPersonByIdShouldReturnPerson(long id)
        {

            for (int i = 0; i < 16; i++)
            {
                Person person = new Person(12345678 + i, "Victor" + i);
                db.Add(person);
            }
            Person personToFind = db.FindById(id);
            long personToFindId = personToFind.Id;
            Assert.AreEqual(id, personToFindId);
        }

        [Test]
        public void FindShouldThrowIfUserIsLowerCase()
        {
            Person person = new Person(12345678, "Victor");
            this.db.Add(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.FindByUsername("victor");
            });
        }
        [Test]
        public void FindShouldThrowExceptionIfIdDoesntExist()
        {
            Person firstPerson = new Person(98, "Victor");
            this.db.Add(firstPerson);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.FindById(123);
            }, "No user is present by this Id!");
        }
    }
}


