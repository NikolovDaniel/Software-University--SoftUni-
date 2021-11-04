using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            List<int> indexAddCollection = new List<int>();
            List<int> indexAddRemoveCollection = new List<int>();
            List<int> indexMyList = new List<int>();

            string[] items = Console.ReadLine().Split();

            for (int i = 0; i < items.Length; i++)
            {
                indexAddCollection.Add(addCollection.Add(items[i]));
                indexAddRemoveCollection.Add(addRemoveCollection.Add(items[i]));
                indexMyList.Add(myList.Add(items[i]));
            }

            int n = int.Parse(Console.ReadLine());

            List<string> resultAddRemoveCollection = new List<string>();
            List<string> resultMyList = new List<string>();

            for (int i = 0; i < n; i++)
            {
                resultAddRemoveCollection.Add(addRemoveCollection.Remove());
                resultMyList.Add(myList.Remove());
            }
            Console.WriteLine(string.Join(" ", indexAddCollection));
            Console.WriteLine(string.Join(" ", indexAddRemoveCollection));
            Console.WriteLine(string.Join(" ", indexMyList));
            Console.WriteLine(string.Join(" ", resultAddRemoveCollection));
            Console.WriteLine(string.Join(" ", resultMyList));
        }
    }
}
