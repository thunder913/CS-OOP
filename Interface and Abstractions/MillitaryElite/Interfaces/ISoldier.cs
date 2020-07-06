using System;
using System.Collections.Generic;
using System.Text;

namespace MillitaryElite
{
    public interface ISoldier
    {
        string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }

    }
}
