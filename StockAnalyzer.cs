using System;
using System.Collections.Generic;
using System.Linq;
 
namespace StockAnalyzer
{
    public class StockAnalyzer
    {
        private decimal priceThreshold;
        private decimal changePercentThreshold;
 
        public StockAnalyzer(IEnumerable<Stock> stocks, decimal priceThreshold, decimal changePercentThreshold)
        {
            this.priceThreshold = priceThreshold;
            this.changePercentThreshold = changePercentThreshold;
 
            foreach (var stock in stocks.Where(s => s.Price > priceThreshold))
            {
                stock.PriceChanged += Stock_PriceChanged;
            }
        }
 
        private void Stock_PriceChanged(object sender, PriceChangedEventArgs e)
        {
            Stock stock = (Stock)sender;
            decimal changePercent = (e.NewPrice - e.OldPrice) / e.OldPrice * 100;
 
            if (Math.Abs(changePercent) >= changePercentThreshold)
            {
                string changeType = changePercent > 0 ? "increased" : "decreased";
                Console.WriteLine($"Alert!. Price {changeType} by {changePercent:F2} %");
            }
        }
    }
}
 