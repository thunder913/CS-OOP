using NUnit.Framework;
using System.Linq;
using System;
using ExtendedDatabase;
namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private static Person[] people = new Person[]
        {
            new Person(1, "Ivan"),
            new Person(2, "Pesho"),
            new Person(3, "Gosho"),
            new Person(4, "Mariq")
        };
        private ExtendedDatabase.ExtendedDatabase database;
        
        [SetUp]
        public void SetUp() 
        {
            database = new ExtendedDatabase.ExtendedDatabase(people);
        }
        [Test]
        public void ConstructorShouldWorkCorrectly() 
        {
            //Act
            var expectedElements = people.Count();
            var actualElements = database.Count;
            //Assert

            Assert.That(actualElements, Is.EqualTo(expectedElements));
        }

        [Test]
        public void AddRangeThrowsExceptionIfParamsCountIsMoreThan16() 
        {
            //Arrange
            var peopleToAdd = new Person[17];
            //Assert
            Assert.That(() => new ExtendedDatabase.ExtendedDatabase(peopleToAdd), //Act
                Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void AddThrowsExceptionIfCountIs16() 
        {
            //Arrange
            for (int i = 0; i < 12; i++)
            {
                database.Add(new Person(i + 5, i.ToString()));
            }
            //Assert
            Assert.That(() => database.Add(null), //Act
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void AddThrowsExceptionIfThereIsAlreadyThisPersonName() 
        {
            //Assert
            Assert.That(() => database.Add(new Person(42, "Ivan")), //Act
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void AddThrowsExceptionIfThereIsAlreadyThisPersonId()
        {
            //Assert
            Assert.That(() => database.Add(new Person(1, "TestSubject")), //Act
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void AddsPeopleCorrectly() 
        {
            //Arrange
            database.Add(new Person(5, "Bat Georgi"));
            //Act
            var expectedCount = people.Count() + 1;
            var actualCount = database.Count;
            //Assert
            Assert.That(expectedCount, Is.EqualTo(actualCount));
        }
        [Test]
        public void RemoveWorksCorrectly() 
        {
            //Arrange
            database.Remove();
            //Act
            var expectedCount = people.Count()-1;
            var actualCount = database.Count;
            //Assert
            Assert.That(expectedCount, Is.EqualTo(actualCount));
        }

        [Test]
        public void RemoveThrowsExceptionIfNoPeople() 
        {
            //Arrange
            database = new ExtendedDatabase.ExtendedDatabase();
            //Assert
            Assert.That(() => database.Remove(), //Act
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void FindByUsernameThrowsExceptionIfNameIsNull() 
        {
            //Assert
            Assert.That(() => database.FindByUsername(null), //Act
                Throws.InstanceOf<ArgumentNullException>());
        }
        [Test]
        public void FindByUsernameThrowsExceptionIfNameIsEmpty()
        {
            //Assert
            Assert.That(() => database.FindByUsername(string.Empty), //Act
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void FindByUsernameThrowsExceptionIfThereIsNoSuchPerson()
        {
            //Assert
            Assert.That(() => database.FindByUsername("Bai Ivan"), //Act
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void FindByUsernameArgumentsAreCaseSensitive()
        {
            Assert.That(() => database.FindByUsername("gosho")
            , Throws.InstanceOf<InvalidOperationException>());
        }
        [Test]
        public void FindByUserNameWorksCorrectly() 
        {
            //Arrange
            var person = database.FindByUsername("Ivan");
            //Act
            var expectedAnswer = new Person(1, "Ivan");
            //Assert
            Assert.That(expectedAnswer.UserName, Is.EqualTo(person.UserName));
            Assert.That(expectedAnswer.Id, Is.EqualTo(person.Id));
        }

        [Test]
        public void FindByIdThrowsExceptionIfIdIsNegative() 
        {
            //Assert
            Assert.That(() => database.FindById(-1), //Act
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void FindByIdThrowsExceptionIfThereIsNoSuchPerson()
        {
            //Assert
            Assert.That(() => database.FindById(42), //Act
                Throws.InstanceOf<InvalidOperationException>());
        }
        [Test]
        public void FindByIdWorksCorrectly()
        {
            //Arrange
            var person = database.FindById(1);
            //Act
            var expectedAnswer = new Person(1, "Ivan");
            //Assert
            Assert.That(expectedAnswer.UserName, Is.EqualTo(person.UserName));
            Assert.That(expectedAnswer.Id, Is.EqualTo(person.Id));
        }
    }
}
