using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface INameable:IBuyer
    {
        string Name { get; set; }
    }
}
