using System.Collections.Generic;

namespace CollectionHierarchy
{
    public interface IMyList
    {
        public List<string> Data { get; }

        int Add(string item)
        {
            Data.Insert(0, item);

            return 0;
        }

        string Remove()
        {
            string item = Data[0];

            Data.RemoveAt(0);

            return item;
        }

        int Used()
        {
            return Data.Count;
        }
    }
}