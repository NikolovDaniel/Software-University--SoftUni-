using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        public List<string> Data { get; private set; }

        public AddCollection()
        {
            this.Data = new List<string>();
        }

        public int Add(string item)
        {
            Data.Add(item);

            return Data.Count - 1;
        }

    }
}
