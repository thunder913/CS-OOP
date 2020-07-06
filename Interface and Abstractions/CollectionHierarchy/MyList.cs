using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace CollectionHierarchy
{
    public class MyList :AddRemoveCollection, IMyList
    {
        public MyList()
        {
            collection = new List<string>();
        }

        public int User => collection.Count();
        public string Remove()
        {
            var itemRemove = collection[0];
            collection.RemoveAt(0);
            return itemRemove;
        }
    }
}
