using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public interface IAddCollection
    {
        public List<string> collection { get; set; }
        public int Add(string item);
    }
}
