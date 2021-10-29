using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        private decimal money;

        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        private List<Product> bagOfProducts;

        public List<Product> BagOfProducts
        {
            get { return bagOfProducts; }
            set { bagOfProducts = value; }
        }


        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public void BuyProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                Console.WriteLine($"{this.Name} bought {product.Name}");
                this.Money -= product.Cost;
                this.BagOfProducts.Add(product);
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            if (this.BagOfProducts.Count > 0)
            {
                return $"{this.Name} - {string.Join(", ", this.BagOfProducts.Select(x => x.Name).ToList())}";
            }
            else
            {
                return $"{this.Name} - Nothing bought";
            }
        }
    }
}
