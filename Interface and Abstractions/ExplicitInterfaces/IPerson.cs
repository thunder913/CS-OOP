using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    interface IPerson:INameable
    {
        int Age { get; set; }
        public string GetName();
    }
}
