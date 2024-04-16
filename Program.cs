using System;
using System.Collections.Generic;
 
namespace StockAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Stock> stocks = new List<Stock>();
            string symbol;
            decimal price;
 
            Console.WriteLine("Enter stock data (symbol, price) or type '!' to finish:");
            while (true)
            {
                Console.Write("Enter stock symbol: ");
                symbol = Console.ReadLine();
 
                if (symbol == "!")
                    break;
 
                Console.Write("Enter stock initial price: ");
                price = GetDecimalInput();
 
                stocks.Add(new Stock(symbol, price));
            }
 
            Console.Write("Enter a threshold price to monitor for change: ");
            decimal priceThreshold = GetDecimalInput();
 
            Console.Write("Enter a threshold price change percent: ");
            decimal changePercentThreshold = GetDecimalInput();
 
            StockAnalyzer analyzer = new StockAnalyzer(stocks, priceThreshold, changePercentThreshold);
 
            foreach (var stock in stocks)
            {
                Console.Write($"For stock with symbol {stock.Symbol}, Please enter the new price: ");
                decimal newPrice = GetDecimalInput();
                stock.Price = newPrice;
            }
        }
        static decimal GetDecimalInput()
        {
            decimal input;
            while (!decimal.TryParse(Console.ReadLine(), out input))
            {
                Console.Write("Invalid input. Please enter a number: ");
            }
            return input;
        }
        static decimal GetDecimalInputT <T>(string prompt) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            decimal input;
            while (!decimal.TryParse(Console.ReadLine(), out input))
            {
                Console.Write("Invalid input. Please enter a number: ");
            }
            return input;
        }
    }
}