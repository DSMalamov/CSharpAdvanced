using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public List<Stock> Portfolio { get; set; }

        public int Count { get { return portfolio.Count; } }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest > 10000)
            {
                this.MoneyToInvest -= stock.MarketCapitalization;
                Portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!Portfolio.Any(c => c.CompanyName == companyName))
            {
                return $"{companyName} does not exist.";
            }
            else
            {
                bool isSold = false;
                foreach (var item in Portfolio)
                {
                    if (item.CompanyName == companyName && item.PricePerShare < sellPrice)
                    {
                        isSold = true;
                    }

                }

                if (!isSold)
                {
                    return $"Cannot sell {companyName}.";
                }
                else
                {
                    Portfolio.RemoveAll(c => c.CompanyName == companyName);
                    MoneyToInvest += sellPrice;
                    return $"{companyName} was sold.";
                }

            }
        }

        public Stock FindStock(string companyName) => Portfolio.FirstOrDefault(c => c.CompanyName == companyName);

        public Stock FindBiggestCompany()
        {
            Stock stock= null;

            foreach (var item in Portfolio)
            {
                if (item.MarketCapitalization > stock.MarketCapitalization)
                {
                    stock = item;
                }
            }

            return stock;
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");

            foreach (var item in Portfolio)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();

        }
    }
}
