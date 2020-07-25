using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Craft(IPresent present, IDwarf dwarf)
        {
            while(dwarf.Energy >= 0 && dwarf.Instruments.Any(x => x.IsBroken() == false) && (present.IsDone()==false))
            {
                var instrument = dwarf.Instruments.First(x => x.IsBroken() == false);
                instrument.Use();
                dwarf.Work();
                present.GetCrafted();
            }
        }
    }
}
