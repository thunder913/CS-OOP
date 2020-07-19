using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }
        [Test]
        public void ArenaConstructorShouldCreateEmptyList() 
        {
            //Assemble
            arena = new Arena();
            //Act
            var expectedCount = 0;
            var actualCount = arena.Count;
            //Assert
            Assert.That(expectedCount, Is.EqualTo(actualCount));
        }

        [Test]
        public void ArenaShouldReturnIReadOnlyCollection() 
        {
            //Assemble
            arena = new Arena();

            //Assert
            Assert.True(arena.Warriors is IReadOnlyCollection<Warrior>);
        }

        [Test]
        public void EnrollShouldWorkCorrectly() 
        {
            //Assemble
            EnrollWarrior(arena);
            //Act
            var expectedCount = 2;
            var actualCount = arena.Count;
            //Assert
            Assert.That(expectedCount, Is.EqualTo(actualCount));
        }

        [Test]
        public void EnrollThrowsExceptionIfTheNewWarriorNameIsInTheArena() 
        {
            //Assemble
            EnrollWarrior(arena);
            
            //Assert
            Assert.That(() => arena.Enroll(new Warrior("Pesho", 99, 250)), //Act
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]

        public void FightThrowsExceptionIfThereIsNoSuchAttacker() 
        {
            //Assemble
            EnrollWarrior(arena);
            //Assert
            Assert.That(() => arena.Fight("Ivailo", "Gosho"),
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]

        public void FightThrowsExceptionIfThereIsNoSuchDefender()
        {
            //Assemble
            EnrollWarrior(arena);
            //Assert
            Assert.That(() => arena.Fight("Gosho", "Ivailo"),
                Throws.InstanceOf<InvalidOperationException>());
        }
        [Test]
        public void FightThrowsExceptionIfAttackerIsNull() 
        {
            //Assemble
            EnrollWarrior(arena);
            //Assert
            Assert.That(() => arena.Fight(null, "Gosho"),
                Throws.InstanceOf<InvalidOperationException>());
        }
        [Test]
        public void FightThrowsExceptionIfDefenderIsNull()
        {
            //Assemble
            EnrollWarrior(arena);
            //Assert
            Assert.That(() => arena.Fight("Gosho", null),
                Throws.InstanceOf<InvalidOperationException>());
        }
        [Test]
        public void FightWorksCorrectly() 
        {
            //Assemble
            EnrollWarrior(arena);
            //Act
            var expectedAttackHp = 100 - 40;
            var expectedDefenderHp = 80 - 50;
            var getFighters = arena.Warriors.ToList();
            arena.Fight("Pesho", "Gosho");
            var firstFighter = getFighters.FirstOrDefault(x => x.Name == "Pesho");
            var secondFighter = getFighters.FirstOrDefault(x => x.Name == "Gosho");
            //Assert
            Assert.That(expectedAttackHp, Is.EqualTo(firstFighter.HP));
            Assert.That(expectedDefenderHp, Is.EqualTo(secondFighter.HP));
        }

        public void EnrollWarrior(Arena arena) 
        {
            arena.Enroll(new Warrior("Pesho", 50, 100));
            arena.Enroll(new Warrior("Gosho", 40, 80));
        }
    }
}
