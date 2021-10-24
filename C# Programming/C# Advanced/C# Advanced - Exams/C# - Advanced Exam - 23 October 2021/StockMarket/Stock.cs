using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket
{
    public class Stock
    {
        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShares { get; set; }
        public decimal MarketCapitalization => PricePerShare * TotalNumberOfShares;

        public Stock(string companyName, string director, decimal priceShare, int numberShares)
        {
            this.CompanyName = companyName;
            this.Director = director;
            this.PricePerShare = priceShare;
            this.TotalNumberOfShares = numberShares;
        }

        public override string ToString()
        {            
            return $"Company: {this.CompanyName}\r\n" +
                $"Director: {this.Director}\r\n" +
                $"Price per share: ${this.PricePerShare:f2}\r\n" + // Потенциална грешка, премахни закръглянето до 2-ри знак
                $"Market capitalization: ${this.MarketCapitalization:f2}"; // Потенциална грешка, премахни закръглянето до 2-ри знак
        }
    }
}
