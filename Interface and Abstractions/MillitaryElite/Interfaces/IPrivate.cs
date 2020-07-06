using System;
using System.Collections.Generic;
using System.Text;

namespace MillitaryElite
{
    public interface IPrivate:ISoldier
    {
        decimal Salary { get; set; }

    }
}
