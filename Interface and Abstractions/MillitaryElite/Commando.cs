using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace MillitaryElite
{
    public class Commando : Private, ICommando
    {
        public Commando(string firstName, string lastName, string id, decimal salary, string corps) : base(firstName, lastName, id, salary)
        {
            this.Missions = new List<Mission>();
            this.Corps = corps;
        }

        public void AddMission(Mission mission) 
        {
            this.Missions.Add(mission);
        }
        public List<Mission> Missions { get; set; }
        private string corps;
        public string Corps {
            get => this.corps;
            set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new Exception("Invalid corps");
                }
                this.corps = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.corps}");
            sb.AppendLine("Missions:");
            foreach (var item in Missions)
            {
                sb.AppendLine("  "+item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
