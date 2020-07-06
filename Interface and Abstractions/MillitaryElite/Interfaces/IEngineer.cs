using System;
using System.Collections.Generic;
using System.Text;

namespace MillitaryElite
{
    public interface IEngineer: ISpecialisedSoldier
    {
        List<Repair> Repairs { get; set; }
    }
}
