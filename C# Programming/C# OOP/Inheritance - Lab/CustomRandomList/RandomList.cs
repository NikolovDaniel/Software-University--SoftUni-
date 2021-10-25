using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public RandomList(IEnumerable<string> items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }
        public string RandomString()
        {
            Random rnd = new Random();

            int index = rnd.Next(0, this.Count);
            string result = this[index];
            this.RemoveAt(index);
            return result;

        }
    }
}
