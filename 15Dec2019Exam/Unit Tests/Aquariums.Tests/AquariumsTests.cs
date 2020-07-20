namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        private Fish fish1 = new Fish("Pesho");
        private Fish fish2 = new Fish("Gosho");
        private Fish fish3 = new Fish("Ivan");
        private Aquarium aqua;
        [SetUp]
        public void SetUp() 
        {
            aqua = new Aquarium("Petur", 5);
        }
        [Test]
        public void FishWorksCorrectly() 
        {
            //Act
            var expectedName = "Pesho";
            var expectedAvailable = true;
            //Assert
            Assert.That(expectedName, Is.EqualTo(fish1.Name));
            Assert.That(expectedAvailable, Is.EqualTo(fish1.Available));
        }

        [Test]
        public void AquariumThrowsExceptionIfNameIsNull() 
        {

            Assert.That(() => new Aquarium(null, 5),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void AquariumThrowsExceptionIfNameIsEmpty() 
        {
            Assert.That(() => new Aquarium(string.Empty, 5),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void AquariumThrowsExceptionIfCapacityIsNegative() 
        {
            Assert.That(() => new Aquarium("Gosho", -1),
                Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void AquariumWorksCorrectly() 
        {
            //Act
            var expectedFish = 0;
            //Assert
            Assert.That(expectedFish, Is.EqualTo(aqua.Count));
        }

        [Test]
        public void AddThrowsExceptionIfAquariumIsFull() 
        {
            //Assemble
            var aquarium = new Aquarium("Gosho", 1);
            //Act
            aquarium.Add(fish1);
            //Assert
            Assert.That(() => aquarium.Add(fish2),
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void AddWorksCorrectly() 
        {
            //Act
            aqua.Add(fish1);
            aqua.Add(fish2);
            var expectedCount = 2;
            //Assert
            Assert.That(expectedCount, Is.EqualTo(aqua.Count));
        }

        [Test]
        public void RemoveThrowsExceptionIfThereIsNoSuchName() 
        {
            //Assemble
            AddFish();

            Assert.That(() => aqua.RemoveFish("Bai Georgi"),
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void RemoveWorksCorrectly() 
        {
            //Assemble
            AddFish();
            //Act
            aqua.RemoveFish("Pesho");
            var expectedCount = 1;
            //Assert
            Assert.That(expectedCount, Is.EqualTo(aqua.Count));
        }

        [Test]
        public void SellFishThrowsExceptionIfNoSuchFish() 
        {
            //Assemble
            AddFish();
            //Assert
            Assert.That(() => aqua.SellFish("Invalid"),
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void SellFishWorksCorreclty() 
        {
            //Assemble
            AddFish();
            //Act
            var fish = aqua.SellFish("Pesho");
            //Assert
            Assert.That(fish.Available, Is.False);
        }

        [Test]
        public void ReportWorksCorrectly() 
        {
            //Assemble
            AddFish();
            //Act
            var expectedOutput = $"Fish available at Petur: Pesho, Gosho";
            var actualOutput = aqua.Report();
            //Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }
        private void AddFish() 
        {
            aqua.Add(fish1);
            aqua.Add(fish2);
        }
        //Assemble

        //Act

        //Assert
    }
}
