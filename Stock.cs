using System;
 
namespace StockAnalyzer
{
    public class Stock
    {
        public event EventHandler<PriceChangedEventArgs> PriceChanged;
 
        private decimal _price;
        public string Symbol { get; }
        public decimal Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    var oldPrice = _price;
                    _price = value;
                    OnPriceChanged(oldPrice, value);
                }
            }
        }
 
        public Stock(string symbol, decimal price)
        {
            Symbol = symbol;
            Price = price;
        }
 
        protected virtual void OnPriceChanged(decimal oldPrice, decimal newPrice)
        {
            PriceChanged?.Invoke(this, new PriceChangedEventArgs(oldPrice, newPrice));
        }
    }
 
    public class PriceChangedEventArgs : EventArgs
    {
        public decimal OldPrice { get; }
        public decimal NewPrice { get; }
 
        public PriceChangedEventArgs(decimal oldPrice, decimal newPrice)
        {
            OldPrice = oldPrice;
            NewPrice = newPrice;
        }
    }
}
 