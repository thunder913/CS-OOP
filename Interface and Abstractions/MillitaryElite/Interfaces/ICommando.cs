using System;
using System.Collections.Generic;
using System.Text;

namespace MillitaryElite
{
    public interface ICommando: ISpecialisedSoldier
    {
        List<Mission> Missions { get; set; }
        
    }
}
