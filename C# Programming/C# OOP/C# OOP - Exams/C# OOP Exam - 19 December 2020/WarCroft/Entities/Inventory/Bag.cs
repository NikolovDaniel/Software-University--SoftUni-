using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private readonly IList<Item> listItems;
        public int Capacity { get; set; }
        public int Load { get => Items.Sum(x => x.Weight); }

        public IReadOnlyCollection<Item> Items { get; }
        public Bag(int capacity)
        {
            this.Capacity = capacity;
            listItems = new List<Item>();
            this.Items = new ReadOnlyCollection<Item>(listItems);
        }
        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            listItems.Add(item);
        }

        public Item GetItem(string name)
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            Item resultItem = Items.FirstOrDefault(x => x.GetType().Name == name);

            if (resultItem == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            listItems.Remove(resultItem);

            return resultItem;
        }
    }
}
