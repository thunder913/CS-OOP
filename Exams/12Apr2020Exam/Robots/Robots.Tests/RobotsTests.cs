namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.ComponentModel.DataAnnotations;

    [TestFixture]
    public class RobotsTests
    {
        private RobotManager robots;
        private Robot Robot1 = new Robot("Ivan", 500);
        private Robot Robot2 = new Robot("Pesho", 350);
        [SetUp]
        public void SetUp()
        {
            robots = new RobotManager(10);
            robots.Add(Robot1);
            robots.Add(Robot2);
        }
        [Test]
        public void RobotConstructorShouldWorkCorrectly()
        {
            string name = "Pesho";
            int battery = 100;
            var robot = new Robot(name, battery);

            Assert.That(name, Is.EqualTo(robot.Name));
            Assert.That(battery, Is.EqualTo(robot.Battery));
            Assert.That(battery, Is.EqualTo(robot.MaximumBattery));
        }

        [Test]
        public void RobotManagerCapacityCannotBeLessThanZero()
        {
            Assert.That(() => new RobotManager(-1),
                Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void RobotManagerConstructorWorksCorrectly()
        {
            int capacity = 14;
            var robotManager = new RobotManager(14);
            Assert.That(capacity, Is.EqualTo(robotManager.Capacity));
        }

        [Test]
        public void RobotManagerAddsCorrectly()
        {
            int expectedCapacity = 2;
            Assert.That(expectedCapacity, Is.EqualTo(robots.Count));
        }

        [Test]
        public void CannotAddRobotsWithSameName()
        {
            Assert.That(() => robots.Add(Robot1),
                Throws.InstanceOf<InvalidOperationException>());
        }
        [Test]
        public void CannotAddRobotWhenCapacityIsFull()
        {
            var robotmanager = new RobotManager(0);
            Assert.That(() => robotmanager.Add(Robot1),
                Throws.InstanceOf<InvalidOperationException>());
        }
        [Test]
        public void AddWorksCorrectly() 
        {
            var robotmanager = new RobotManager(2);
            robotmanager.Add(Robot1);
            robotmanager.Add(Robot2);

            var expected = 2;

            Assert.That(expected, Is.EqualTo(robotmanager.Count));
        }

        [Test]
        public void RemoveWorksCorrectly()
        {
            var nameToRemove = Robot1.Name;
            robots.Remove(nameToRemove);
            int expectedCount = 1;

            Assert.That(expectedCount, Is.EqualTo(robots.Count));
        }

        [Test]
        public void CannotRemoveInExistingRobot() 
        {
            Assert.That(() => robots.Remove("Andon"),
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void CannotWorkInexistingRobot() 
        {
            Assert.That(() => robots.Work("Andon", "", 20),
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void CannotWorkIfRobotDoesNotHaveEnoughBattery() 
        {
            Assert.That(() => robots.Work(Robot1.Name, " ", Robot1.MaximumBattery * 2),
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void CannotChargeRobotWithInvalidName() 
        {
            Assert.That(() => robots.Charge("Andon"),
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void WorkWorksCorrectlyAndRechargeToo()
        {
            var robot = new Robot("Ivailo", 100);

            robots.Add(robot);
            int workToDo = 50;
            robots.Work("Ivailo", "bachkane", workToDo);
            int expected = 50;
            Assert.That(expected, Is.EqualTo(robot.Battery));
            robots.Charge("Ivailo");
            Assert.That(robot.MaximumBattery, Is.EqualTo(robot.Battery));
        }

        
    }
}
