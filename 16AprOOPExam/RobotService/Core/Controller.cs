using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private Garage garage = new Garage();
        private Chip ChipProcedure = new Chip();
        private Charge ChargeProcedure = new Charge();
        private Polish PolishProcedure = new Polish();
        private Rest RestProcedure = new Rest();
        private TechCheck TechCheckProcedure = new TechCheck();
        private Work WorkProcedure = new Work();
        public string Charge(string robotName, int procedureTime)
        {
            IRobot robot = CheckRobot(robotName);
            ChargeProcedure.DoService(robot, procedureTime);
            return string.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Chip(string robotName, int procedureTime)
        {
            IRobot robot = CheckRobot(robotName);
            ChipProcedure.DoService(robot, procedureTime);
            return string.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string History(string procedureType)
        {
            IProcedure procedure = null;
            switch (procedureType)
            {
                case "Charge":
                    procedure = ChargeProcedure;
                    break;
                case "Chip":
                    procedure = ChipProcedure;
                    break;
                case "Polish":
                    procedure = PolishProcedure;
                    break;
                case "Rest:":
                    procedure = RestProcedure;
                    break;
                case "TechCheck":
                    procedure = TechCheckProcedure;
                    break;
                case "Work":
                    procedure = WorkProcedure;
                    break;
            }
            return procedure.History();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            Robot robot;
            switch (robotType)
            {
                case "HouseholdRobot":
                    robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                    break;
                case "PetRobot":
                    robot = new PetRobot(name, energy, happiness, procedureTime);
                    break;
                case "WalkerRobot":
                    robot = new WalkerRobot(name, energy, happiness, procedureTime);
                    break;
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));
            }
            garage.Manufacture(robot);
            return string.Format(OutputMessages.RobotManufactured, name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            IRobot robot = CheckRobot(robotName);
            PolishProcedure.DoService(robot, procedureTime);
            return string.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            IRobot robot = CheckRobot(robotName);
            RestProcedure.DoService(robot, procedureTime);
            return string.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = CheckRobot(robotName);
            garage.Sell(robotName, ownerName);
            if (robot.IsChipped)
            {
                return string.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else 
            {
                return string.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IRobot robot = CheckRobot(robotName);
            TechCheckProcedure.DoService(robot, procedureTime);
            return string.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            IRobot robot = CheckRobot(robotName);
            WorkProcedure.DoService(robot, procedureTime);
            return string.Format(OutputMessages.WorkProcedure, robotName,procedureTime);
        }

        private IRobot CheckRobot(string robotName) 
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            return garage.Robots.First(x => x.Key == robotName).Value;
        }
    }
}
