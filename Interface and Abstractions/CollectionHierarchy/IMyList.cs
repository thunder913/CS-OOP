using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace CollectionHierarchy
{
    public interface IMyList:IAddRemoveCollection
    {
        public int Used { get => this.collection.Count();}
    }
}
