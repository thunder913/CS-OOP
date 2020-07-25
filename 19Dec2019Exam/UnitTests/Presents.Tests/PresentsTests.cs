namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection.Metadata;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;
        private Present present1 = new Present("Ivan", 5);
        private Present present2 = new Present("Gosho", 15);
        [SetUp]
        public void SetUp() 
        {
            this.bag = new Bag();
        }
        [Test]
        public void PresentWorksCorrectly() 
        {
            //Assemble
            var expectedName = "Gosho";
            var expectedMagic = 5;
            var present = new Present(expectedName, expectedMagic);
            //Assert
            Assert.That(expectedName, Is.EqualTo(present.Name));
            Assert.That(expectedMagic, Is.EqualTo(present.Magic));
        }

        [Test]
        public void ConstructorWorksCorrectly() 
        {
            //Act
            var expectedCount = 0;
            //Assert
            Assert.That(expectedCount, Is.EqualTo(bag.GetPresents().Count));
        }

        [Test]
        public void GetPresentsIsAIReadOnlyCollection() 
        {
            //Assert
            Assert.That(bag.GetPresents() is IReadOnlyCollection<Present>);
        }

        [Test]
        public void CreateThrowsExceptionIfNullPresent() 
        {
            //Assert
            Assert.That(() => bag.Create(null),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void CreateThrowsExceptionIfThereIsAlreadyThisPresent() 
        {
            //Assemble
            bag.Create(present1);
            //Assert
            Assert.That(() => bag.Create(present1),
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void CreateWorksCorrectly() 
        {
            //Act
            var actualMessageOne = bag.Create(present1);
            var actualMessageTwo = bag.Create(present2);
            var expectedOutputOne = $"Successfully added present {present1.Name}.";
            var expectedOutputTwo = $"Successfully added present {present2.Name}.";
            var expectedCount = 2;
            var actualCount = bag.GetPresents().Count;

            Assert.That(expectedOutputOne, Is.EqualTo(actualMessageOne));
            Assert.That(expectedOutputTwo, Is.EqualTo(actualMessageTwo));
            Assert.That(expectedCount, Is.EqualTo(actualCount));
        }

        [Test]
        public void RemovesPresentItem() 
        {
            //Assemble
            bag.Create(present1);
            //Assert
            Assert.IsTrue(bag.Remove(present1));
        }

        [Test]
        public void RemoveReturnFalseIfNoPresentThere() 
        {
            //Assemble
            bag.Create(present1);
            //Assert
            Assert.IsFalse(bag.Remove(present2));
        }

        [Test]
        public void GetPresentWithLeastMagicWorksCorrectly() 
        {
            //Assemble
            bag.Create(present1);
            bag.Create(present2);
            var actualPresent = bag.GetPresentWithLeastMagic();
            //Assert
            Assert.That(present1.Equals(actualPresent));
        }

        [Test]
        public void GetPresentWithLeastMagicThrowsExceptionIfThereAreNoPresents() 
        {
            //Assert
            Assert.That(() => bag.GetPresentWithLeastMagic(),
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void GetPresentWorksCorrectly() 
        {
            //Assemble
            bag.Create(present1);
            bag.Create(present2);
            //Act
            var present = bag.GetPresent(present1.Name);

            //Assert
            Assert.That(present1, Is.EqualTo(present));
        }

        [Test]
        public void GetPresentWorksWHenCollectionIsEmpty() 
        {
            //Assemble
            bag.Create(present1);
            bag.Create(present2);
            //Act
            var present = bag.GetPresent("Invalid");
            //Assert
            Assert.IsNull(present);
        }

        [Test]
        public void GetPresentsReturnEmptyCollectionIfNoPresents() 
        {
            //Act
            var collection = bag.GetPresents();
        }

    }
}
