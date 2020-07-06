using System;
using System.Collections.Generic;
using System.Text;

namespace MillitaryElite
{
    public class Mission
    {

        public Mission(string name, string state)
        {
            this.CodeName = name;
            this.State = state;

        }
        private string state;
        public string CodeName { get; set; }
        public string State
        {
            get => this.state;
            set
            {
                if (value != "Finished" && value != "inProgress")
                {
                    throw new ArgumentException("The state has an invalid value!");
                }
                this.state = value;
            }
        }

        public void CompleteMission()
        {
            if (this.State == "inProgress")
            {
                this.State = "Finished";
            }
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.state}";
        }
    }
}
