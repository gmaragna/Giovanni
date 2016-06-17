using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryTest
{
    public class Trade
    {
        public Trade()
        {
            TimeStamp = DateTime.Now;
            TradeDirection = TradeDirectionEnum.Buy;
            SharesNumber = 0;
        }


        public DateTime TimeStamp { get; set; }
        public TradeDirectionEnum TradeDirection { get; set; }

        public long SharesNumber { get; set; }
        public Decimal Price { get; set; }
        public Stock Stock { get; set; }


        public override string ToString()
        {
            //return base.ToString();

            return String.Format("Trade:  {0}, timestamp:{1}, tradedirection:{2}, No of shares: {3},  price:{4} ",
               Stock.Symbol,
               TimeStamp.ToString("yyyyMMddHHmmssfff"),
               TradeDirection.ToString(),
               SharesNumber,
               Price.ToString("F")
              
               );

        }


       
    }
}
