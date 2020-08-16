using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private Computer computerOne;
        private Computer computerTwo;
        private ComputerManager manager;
        [SetUp]
        public void Setup()
        {
            computerOne = new Computer("Asus", "Rog", 1000);
            computerTwo = new Computer("Razer", "Kreken", 1500);
            manager = new ComputerManager();
        }

        

        [Test]
        public void CountWorksCorrectly() 
        {
            Assert.That(manager.Count, Is.EqualTo(0));
        }
        [Test]
        public void ComputerWorksCorrecly()
        {
            Assert.That(computerOne.Manufacturer, Is.EqualTo("Asus"));
            Assert.That(computerOne.Model, Is.EqualTo("Rog"));
            Assert.That(computerOne.Price, Is.EqualTo(1000));
        }
        [Test]
        public void ComputersRetursIReadOnlyCollection() 
        {
            var computers = manager.Computers;
            Assert.That(computers is IReadOnlyCollection<Computer>);
            Assert.IsEmpty(computers);

            manager.AddComputer(computerOne);
            manager.AddComputer(computerTwo);
            var computerSecondTry = manager.Computers;
            Assert.That(computerSecondTry.Count(), Is.EqualTo(2));
        }

        [Test]
        public void AddComputerWorksCorrectly() 
        {
            manager.AddComputer(computerOne);
            var expectedCount = 1;
            Assert.That(manager.Count, Is.EqualTo(expectedCount));
            Assert.That(manager.Computers.First().Equals(computerOne));
        }

        [Test]
        public void AddComputerThrowsExceptionIfNull() 
        {
            Assert.That(() => manager.AddComputer(null),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void AddComputerThrowsExceptionIfSameComputer() 
        {
            manager.AddComputer(computerOne);
            Assert.That(() => manager.AddComputer(computerOne),
                Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void RemoveComputerWorksCorrectly() 
        {
            manager.AddComputer(computerOne);
            manager.AddComputer(computerTwo);
            var removed = manager.RemoveComputer(computerOne.Manufacturer, computerOne.Model);
            var expectedCount = 1;
            Assert.That(manager.Count, Is.EqualTo(expectedCount));
            Assert.That(removed, Is.EqualTo((computerOne)));
        }

        [Test]
        public void RemoveThrowsExceptionIfAnyArgumentIsNull() 
        {
            manager.AddComputer(computerOne);
            Assert.That(()=>manager.RemoveComputer(null, computerOne.Model),
                Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => manager.RemoveComputer(computerOne.Manufacturer, null),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void RemoveThrowsExceptionIfNoSuchComputer() 
        {
            manager.AddComputer(computerOne);
            Assert.That(() => manager.RemoveComputer(computerTwo.Manufacturer, computerTwo.Model),
                Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void GetComputersByManufacturerThrowsExceptionIfNullArgument() 
        {
            Assert.That(() => manager.GetComputersByManufacturer(null),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetComputerManufacturerWorksCorrectly() 
        {
            manager.AddComputer(computerOne);
            manager.AddComputer(computerTwo);
            manager.AddComputer(new Computer(computerOne.Manufacturer, "random", 22));
            var emptyList = manager.GetComputersByManufacturer("Empty");
            Assert.That(emptyList.Count(), Is.EqualTo(0));

            var asusComputers = manager.GetComputersByManufacturer(computerOne.Manufacturer);
            Assert.That(asusComputers.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetComputersManufacturerReturnsEmptyIfEmpty() 
        {
            var getcomputers = manager.GetComputersByManufacturer("a");
            Assert.IsEmpty(getcomputers);
            Assert.That(getcomputers is ICollection<Computer>);
        }
        [Test]
        public void GetComputerWorksCorrectly() 
        {
            manager.AddComputer(computerOne);
            manager.AddComputer(computerTwo);

            var computer = manager.GetComputer(computerOne.Manufacturer, computerOne.Model);
            Assert.That(computer, Is.EqualTo(computerOne));
        }

        [Test]
        public void GetComputerThrowsExceptionIfArgumentsAreNull() 
        {
            Assert.That(() => manager.GetComputer(null, computerOne.Model),
                    Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => manager.GetComputer(computerOne.Manufacturer, null),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetComputerThrowsExceptionIfNoSuchComputer() 
        {
            Assert.That(() => manager.GetComputer("pesho", "gosho"),
                Throws.InstanceOf<ArgumentException>());
        }
    }
}