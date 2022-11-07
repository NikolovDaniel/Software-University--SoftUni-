using System.Collections.Generic;

namespace CollectionHierarchy
{
    public interface IAddRemoveCollection
    {
        public List<string> Data { get; }

        int Add(string item)
        {
            Data.Insert(0, item);

            return 0;
        }

        string Remove()
        {
            string item = Data[Data.Count - 1];
            Data.RemoveAt(Data.Count - 1);

            return item;
        }
    }
}