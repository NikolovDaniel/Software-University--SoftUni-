using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> Portfolio;

        public string FullName { get; set; }
        public string EmailAdress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count => Portfolio.Count;

        public Investor(string fullName, string email, decimal moneyInvest, string brokerName)
        {
            this.FullName = fullName;
            this.EmailAdress = email;
            this.MoneyToInvest = moneyInvest;
            this.BrokerName = brokerName;
            this.Portfolio = new List<Stock>();
        }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000)
            {
                if (this.MoneyToInvest >= stock.PricePerShare)
                {
                    this.MoneyToInvest -= stock.PricePerShare;
                    this.Portfolio.Add(stock);
                }
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            foreach (var stock in Portfolio)
            {
                if (stock.CompanyName == companyName)
                {
                    if (sellPrice < stock.PricePerShare)
                    {
                        return $"Cannot sell {companyName}.";
                    }
                    else
                    {
                        this.MoneyToInvest += sellPrice;
                        this.Portfolio.Remove(stock);
                        return $"{companyName} was sold.";
                    }
                }
            }

            return $"{companyName} does not exist.";
        }

        public Stock FindStock(string companyName)
        {
            return Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        }
        public Stock FindBiggestCompany()
        {
            return Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
        {
            string result = $"The investor {this.FullName} with a broker {this.BrokerName} has stocks:\r\n";

            foreach (var item in Portfolio)
            {
                result += $"{item}\r\n";
            }

            return result; // Потенциална грешка, опитай с result.TrimEnd();
        }
    }
}
