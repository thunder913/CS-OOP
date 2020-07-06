using System;
using System.Collections.Generic;
using System.Text;

namespace MillitaryElite
{
    public interface ISpecialisedSoldier : IPrivate
    {
        public string Corps
        {
            get; set;
        }

    }
}
