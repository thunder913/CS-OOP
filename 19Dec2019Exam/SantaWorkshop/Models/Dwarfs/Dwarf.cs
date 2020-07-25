using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public abstract class Dwarf : IDwarf
    {
        public Dwarf(string name, int energy) 
        {
            this.Name = name;
            this.Energy = energy;
        }

        private List<IInstrument> instruments = new List<IInstrument>();
        private string name;
        private int energy;
        public string Name { get => this.name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }
                this.name = value;
            }
        }

        public int Energy { get => this.energy;
        protected set 
            {
                if (value<0)
                {
                    this.energy = 0;
                }
                this.energy = value;
            }
        }

        public ICollection<IInstrument> Instruments => this.instruments;

        public void AddInstrument(IInstrument instrument)
        {
            this.instruments.Add(instrument);
        }

        public abstract void Work();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Energy: {this.Energy}");
            sb.AppendLine($"Instruments: {this.Instruments.Count(x=>x.IsBroken() == false)} not broken left");
            return sb.ToString().TrimEnd();
        }
    }
}
