using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        public List<string> collection { get; set; }

        public AddRemoveCollection() 
        {
            this.collection = new List<string>();
        }
        public int Add(string item)
        {
            collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            var index = collection.Count() - 1;
            var itemRemoved = collection[index];
            collection.RemoveAt(index);
            return itemRemoved;
        }
    }
}
