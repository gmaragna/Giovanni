using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryTest
{
    public class Stock
    {
        private decimal dividendyield = 0;
        private decimal peratio = 0;


        public string Symbol { get; set; }
        public StockTypeEnum StockType { get; set; }
        public decimal LastDividend { get; set; }
        public decimal FixedDividend { get; set; }
        public decimal ParValue { get; set; }
        public decimal TickerPrice { get; set; }
        public string Currency { get; set; }




        //Constructor
        public Stock(string symbol, string currency, StockTypeEnum stocktype, decimal lastdividend, decimal fixeddividend, decimal parvalue, decimal tickerprice)
        {
            Symbol = symbol;
            Currency = currency;
            StockType = stocktype;
            LastDividend = lastdividend;
            FixedDividend = fixeddividend;
            ParValue = parvalue;
            TickerPrice = tickerprice;
        }





        public decimal Calculate_DividendYield()
        {
           
            if(TickerPrice >=0)
            {
                
                if(StockType == StockTypeEnum.Common) 
                {
                    // Common
                    dividendyield = LastDividend / TickerPrice;

                }
                else  
                {
                    //Preferred
                    dividendyield = (FixedDividend * ParValue) / TickerPrice;

                }
                return dividendyield;



            }
            else
            {
                return 0; 
            }




        }

        public decimal Calculate_PERatio()
        {
            // TickerPrice / Dividend
            if(TickerPrice !=0)
            {
                peratio = TickerPrice / Calculate_DividendYield();
            }
            else
            {
                peratio = 0;
            }
            return peratio ;
        }

        

        public override string  ToString()
        {
            return String.Format("Stock:  {0}, currency:{1}, type:{2}, socktype:{3}, lastdividend: {4},  fixeddividend:{5}, parvalue:{6} ",
                Symbol,
                Currency,
                StockType.ToString(),
                LastDividend.ToString("F"),
                FixedDividend.ToString("F"),
                StockType.ToString("F"),
                ParValue.ToString("F")
                );
               
        }

       


    }
}
