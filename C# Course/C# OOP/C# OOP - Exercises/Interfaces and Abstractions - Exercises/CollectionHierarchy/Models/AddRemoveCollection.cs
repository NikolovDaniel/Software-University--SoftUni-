using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        public List<string> Data { get; private set; }
        public AddRemoveCollection()
        {
            this.Data = new List<string>();
        }
        public int Add(string item)
        {
            Data.Insert(0, item);

            return 0;
        }

        public string Remove()
        {
            string item = Data[Data.Count - 1];
            Data.RemoveAt(Data.Count - 1);

            return item;
        }
    }
}
