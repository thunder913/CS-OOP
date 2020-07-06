using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillitaryElite
{
    public class Engineer : Private, IEngineer
    {
        
        public Engineer(string firstName, string lastName, string id, decimal salary,string corps) : base(firstName, lastName, id, salary)
        {
            this.Corps = corps;
        }

        public void AddRepair(Repair repair) 
        {
            Repairs.Add(repair);
        }

        public List<Repair> Repairs { get; set; } = new List<Repair>();
        public string Corps
        {
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
        private string corps { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.corps}");
            sb.AppendLine("Repairs:");
            foreach (var item in Repairs)
            {
                sb.AppendLine("  "+item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
