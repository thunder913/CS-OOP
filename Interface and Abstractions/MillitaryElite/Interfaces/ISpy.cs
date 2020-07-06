using System;
using System.Collections.Generic;
using System.Text;

namespace MillitaryElite
{
    public interface ISpy:ISoldier
    {
        int CodeNumber { get; set; }
    }
}
