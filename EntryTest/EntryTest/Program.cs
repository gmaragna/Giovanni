using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryTest
{
    class Program
    {
        static void Main(string[] args)
        {

            TradeMng stockmanager = new TradeMng();
            //sample stock data
            stockmanager.AddStock(new Stock("TEA", "GBP",  StockTypeEnum.Common, 0, 0, 100, 100));
            stockmanager.AddStock(new Stock("POP", "GBP",  StockTypeEnum.Common, 8, 0, 100, 100));
            stockmanager.AddStock(new Stock("ALE", "GBP",  StockTypeEnum.Common, 23, 0, 60, 60));
            stockmanager.AddStock(new Stock("JIN", "GBP",  StockTypeEnum.Preferred, 0, 20, 100, 100));
            stockmanager.AddStock(new Stock("JOE", "GBP",  StockTypeEnum.Common, 13, 0, 250, 250));



            List<Stock> stocks = stockmanager.GetStocks();




            foreach (var s in stocks)
            {
                // stock list
                Console.WriteLine("--------------STOCKS LIST -----------------------");
                Console.WriteLine(s.ToString());
            }



            //Record Trade with simulation data


            // BEGIN from  11:00 am to 11:15 am
            DateTime timestamp = new DateTime(2016, 06, 17, 11, 0, 0);
            stockmanager.AddTrade("TEA", timestamp, TradeDirectionEnum.Buy, 10, 101);

            stockmanager.AddTrade("TEA", timestamp, TradeDirectionEnum.Buy, 10, 101);
            stockmanager.AddTrade("POP", timestamp, TradeDirectionEnum.Buy, 11, 101);
            stockmanager.AddTrade("ALE", timestamp, TradeDirectionEnum.Buy, 3, 101);
            stockmanager.AddTrade("JIN", timestamp, TradeDirectionEnum.Buy, 4, 101);
            stockmanager.AddTrade("JOE", timestamp, TradeDirectionEnum.Buy, 5, 101);
            








            timestamp = new DateTime(2016, 06, 17, 11, 1, 0);
            stockmanager.AddTrade("TEA", timestamp, TradeDirectionEnum.Buy, 8, 102);

            timestamp = new DateTime(2016, 06, 17, 11, 2, 0);
            stockmanager.AddTrade("ALE", timestamp, TradeDirectionEnum.Buy, 10, 62);


            timestamp = new DateTime(2016, 06, 17, 11, 3, 0);
            stockmanager.AddTrade("TEA", timestamp, TradeDirectionEnum.Buy, 10, 111);


            timestamp = new DateTime(2016, 06, 17, 11, 14, 0);
            stockmanager.AddTrade("TEA", timestamp, TradeDirectionEnum.Buy, 10, 111);

            // END from  11:00 am to 11:15 am


            timestamp = new DateTime(2016, 06, 17, 11, 14, 0);
            stockmanager.AddTrade("TEA", timestamp, TradeDirectionEnum.Buy, 10, 111);



            DateTime fromdatetime = new DateTime(2016, 06, 17, 11, 0, 0);  //11:00 am
            DateTime todatetime = new DateTime(2016, 06, 17, 11, 15, 0);   //11:15 am




            // Geometric Mean

            decimal teaStockPrice = stockmanager.CalculateStockPrice("TEA", fromdatetime, todatetime);

            Console.WriteLine(String.Format("Tea stock price={0}", teaStockPrice.ToString("F")));


            double geometricMean = stockmanager.CalculateGeometricMean( fromdatetime, todatetime);

            Console.WriteLine(String.Format("Geometric Mean={0}", geometricMean.ToString("F")));








            Console.Read();
        }
    }
}
