using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Presents;
using System.Security.Cryptography.X509Certificates;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        public Controller() { }
        private DwarfRepository dwarfs = new DwarfRepository();
        private PresentRepository presents = new PresentRepository();

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf;
            switch (dwarfType)
            {
                case "HappyDwarf":
                    dwarf = new HappyDwarf(dwarfName);
                    break;
                case "SleepyDwarf":
                    dwarf = new SleepyDwarf(dwarfName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }
            dwarfs.Add(dwarf);

            return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            var dwarf = dwarfs.FindByName(dwarfName);
            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }
            var instrument = new Instrument(power);
            dwarf.AddInstrument(instrument);
            return string.Format(OutputMessages.InstrumentAdded, power, dwarfName);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            var present = new Present(presentName, energyRequired);
            this.presents.Add(present);
            return string.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            var present = presents.FindByName(presentName);
            var workers = dwarfs.Models.ToList().Where(x => x.Energy >= 50).OrderByDescending(x=>x.Energy).ToList();
            while (!present.IsDone())
            {
                if (!workers.Any())
                {
                    throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
                }
                var currentDwarf = workers.FirstOrDefault(x=>x.Instruments.Any(x=>x.IsBroken()==false));
                if (currentDwarf == null)
                {
                    return string.Format(OutputMessages.PresentIsNotDone, presentName);
                }
                while (currentDwarf.Energy>0 && !present.IsDone() && currentDwarf.Instruments.FirstOrDefault(x => x.IsBroken() == false) != null)
                {
                    currentDwarf.Work();
                    present.GetCrafted();
                    currentDwarf.Instruments.First(x => x.IsBroken() == false).Use();
                }
                if (currentDwarf.Energy <= 0)
                {
                    dwarfs.Remove(currentDwarf);
                    workers.RemoveAt(0);
                }
            }

            if (present.IsDone())
            {
                return string.Format(OutputMessages.PresentIsDone, presentName);
            }
            else 
            {
                return string.Format(OutputMessages.PresentIsNotDone, presentName);
            }
        }

        public string Report()
        {
            var countOfCraftedPresents = presents.Models.ToList().Count(x => x.IsDone() == true);
            var sb = new StringBuilder();
            sb.AppendLine($"{countOfCraftedPresents} presents are done!");
            sb.AppendLine("Dwarfs info:");
            foreach (var item in dwarfs.Models)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
