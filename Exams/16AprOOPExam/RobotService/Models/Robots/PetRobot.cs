using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Robots
{
    public class PetRobot : Robot
    {
        public PetRobot(string name, int energy, int happines, int procedureTime) : base(name, energy, happines, procedureTime)
        {
        }
    }
}
