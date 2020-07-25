using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Presents
{
    public class Present : IPresent
    {
        public Present(string name, int energyRequired) 
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }
        private int energyRequired;
        private string name;
        public string Name { get => this.name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPresentName);
                }
                this.name = value;
            }
        }

        public int EnergyRequired { get => this.energyRequired;
            private set 
            {
                if (value < 0)
                {
                    this.energyRequired = 0;
                }
                this.energyRequired = value;
            }
        }

        public void GetCrafted()
        {
            this.EnergyRequired -= 10;
        }

        public bool IsDone()
        {
            if (this.EnergyRequired == 0)
            {
                return true;
            }
            return false;
        }
    }
}
