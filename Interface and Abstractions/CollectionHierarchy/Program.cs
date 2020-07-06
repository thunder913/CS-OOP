using System;
using System.Linq;
namespace CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            var inputs = Console.ReadLine().Split();

                AddAllItems(addCollection, inputs);
                AddAllItems(addRemoveCollection, inputs);
                AddAllItems(myList, inputs);

            var toRemove = int.Parse(Console.ReadLine());

            RemoveItems(addRemoveCollection, toRemove);
            RemoveItems(myList, toRemove);
        }

        public static void RemoveItems(IAddRemoveCollection collection, int count) 
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(collection.Remove() + " ");
            }
            Console.WriteLine();
        }
        public static void AddAllItems(IAddCollection collection, string[] items) 
        {
            foreach (var item in items)
            {
                Console.Write(collection.Add(item)+" ");
            }
            Console.WriteLine();
        }
    }
}
