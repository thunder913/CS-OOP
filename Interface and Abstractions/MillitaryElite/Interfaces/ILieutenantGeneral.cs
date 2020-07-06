using System;
using System.Collections.Generic;
using System.Text;

namespace MillitaryElite
{
    public interface ILieutenantGeneral:IPrivate
    {
        List<Private> Privates { get; set; }
    }
}
