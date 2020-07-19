using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {

        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("BMW", "X5", 5, 100);
        }

        [Test]
        public void CarConstructorWorksCorrectly() 
        {
            Assert.That(car.Make, Is.EqualTo("BMW"));
            Assert.That(car.Model, Is.EqualTo("X5"));
            Assert.That(car.FuelConsumption, Is.EqualTo(5));
            Assert.That(car.FuelCapacity, Is.EqualTo(100));
        }

        [Test]
        public void CarMakeCannotBeNull() 
        {
            //Assert
            Assert.That(() => new Car(null, "X5", 5, 100), //Act
                Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void CarMakeCannotBeEmpty()
        {
            //Assert
            Assert.That(() => new Car(string.Empty, "X5", 5, 100), //Act
                Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void CarModelCannotBeNull()
        {
            //Assert
            Assert.That(() => new Car("BMW", null, 5, 100), //Act
                Throws.InstanceOf<ArgumentException>());
        }
        [Test]
        public void CarModelCannotBeEmpty()
        {
            //Assert
            Assert.That(() => new Car("BMW", string.Empty, 5, 100), //Act
                Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void FuelConsumptionCannotBeZeroOrNegative() 
        {
            //Assert
            Assert.That(() => new Car("BMW", "X5", 0, 100), //Act
                Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void FuelCapacityCannotBeZeroOrNegative()
        {
            //Assert
            Assert.That(() => new Car("BMW", "X5", 5, 0), //Act
                Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void RefuelAmmountCannotBeZeroOrNegative() 
        {
            //Assert
            Assert.That(() => car.Refuel(0), //Act
                Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void RefuelWorksCorrectly() 
        {
            //Act
            var expectedAmount = car.FuelAmount + 5;
            car.Refuel(5);
            //Assert
            Assert.That(expectedAmount, Is.EqualTo(car.FuelAmount));
        }

        [Test]
        public void RefuelWorksCorrectlyIfItGoesOverTheLimit() 
        {
            //Act
            var expectedFuel = car.FuelCapacity;
            car.Refuel(1000);
            //Assert
            Assert.That(expectedFuel, Is.EqualTo(car.FuelAmount));
        }

        [Test]
        public void DriveThrowsExceptionIfTheDistanceIsTooMuch() 
        {
            //Assert
            Assert.That(() => car.Drive(5), //Act
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void DriveWorksCorrectly() 
        {
            //Arrange
            car.Refuel(10);
            //Act
            var expectedFuel = 5;
            car.Drive(100);
            var actualFuel = car.FuelAmount;
            //Assert

            Assert.That(expectedFuel, Is.EqualTo(actualFuel));
        }
        //Arrange

        //Act

        //Assert
    }
}