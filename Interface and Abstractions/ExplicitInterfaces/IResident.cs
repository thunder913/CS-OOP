using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    public interface IResident:INameable
    {
        string Country { get; set; }
        public string GetName();
    }
}
