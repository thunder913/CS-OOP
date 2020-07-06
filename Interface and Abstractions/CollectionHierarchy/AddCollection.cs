using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        public List<string> collection { get; set; }
        public AddCollection() 
        {
            this.collection = new List<string>();
        }
        public int Add(string item)
        {
            collection.Add(item);
            return collection.Count()-1;
        }
    }
}
