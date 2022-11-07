using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : IMyList
    {
        public List<string> Data { get; private set; }

        public MyList()
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
            string item = Data[0];

            Data.RemoveAt(0);

            return item;
        }
        public int Used()
        {
            return Data.Count;
        }
    }
}
