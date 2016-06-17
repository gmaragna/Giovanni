using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryTest
{
    /// <summary>
    /// Stock Manager
    /// </summary>
    public class TradeMng
    {
        Dictionary<string, Stock> _stocks = new Dictionary<string, Stock>();
        List<Trade> _trades = new List<Trade>();

        public bool AddStock(Stock stock)
        {
            string stocksymbol = stock.Symbol;
            if(_stocks.ContainsKey(stocksymbol))
            {
                //stock already added
                // I can replace the old value or discard the new
                // in this case I discard the stock added

                return false;
            }
            else
            {
                _stocks.Add(stocksymbol, stock);
                return true;
            }

        }
        public List<Stock> GetStocks()
        {
            return _stocks.Values.ToList(); 
        }

        public Stock GetStockBySymbol(string symbol)
        {
            
            return _stocks[symbol];
        }


        //override trade
        public void AddTrade(string symbol, DateTime timestamp,  TradeDirectionEnum tradedirection, long sharesnumber, decimal price)
        {
            Trade t = new Trade();
            t.Stock = GetStockBySymbol(symbol);
            t.TimeStamp = timestamp;
            t.TradeDirection = tradedirection;
            t.SharesNumber = sharesnumber;
            t.Price = price;

            _trades.Add(t);

        }

        public void AddTrade(Trade  trade)
        {
            _trades.Add(trade);
        }

        public decimal CalculateStockPrice(string symbol, DateTime fromdatetime, DateTime todatetime)
        {
            decimal sp_numerator = 0;
            decimal sp_denominator = 0;


            List<Trade> temptrades = (from t in _trades
                                     where
                   t.Stock.Symbol == symbol
                   && t.TimeStamp >= fromdatetime
                   && t.TimeStamp <= todatetime
                                     select t).ToList();

            foreach(var t in temptrades)
            {

                sp_numerator += t.Price * t.SharesNumber;
                sp_denominator += t.SharesNumber;
            }


            if (sp_denominator > 0)
                return sp_numerator / sp_denominator;
            else
                return 0;


        }


        public double CalculateGeometricMean(DateTime fromdatetime, DateTime todatetime)
        {
            List<decimal> prices = new List<decimal>();

            foreach(var stock in _stocks)
            {
                decimal price = CalculateStockPrice(stock.Key, fromdatetime, todatetime);
                prices.Add(price);
                

            }


            decimal prod=1;
            if (prices.Count > 0)
            {
                foreach (var p in prices)
                {
                    prod = prod * p;
                }

                return Math.Pow((double)prod, (double)1 / prices.Count);
            }
            else
            {
                return 0;
            }




            

        }

    }
}
