using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {

        private const int CAPACITY = 10;
        private Dictionary<string, IRobot> robots = new Dictionary<string, IRobot>();
        public IReadOnlyDictionary<string, IRobot> Robots => robots;

        public void Manufacture(IRobot robot)
        {
            if (robots.Count() >= CAPACITY)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            if (robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }

            robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            var robot = robots.First(x=>x.Key == robotName).Value;
            robot.Owner = ownerName;
            robot.IsBought = true;
            robots.Remove(robot.Name);
        }
    }
}
