using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhavCopyParser.DataModels.EquityData
{
    public class OHLC
    {
        public OHLC(string open, string high, string low, string close, string volume, string date, string numberOfTrades)
        {
            Open = Convert.ToDouble(open);
            High = Convert.ToDouble(high);
            Low = Convert.ToDouble(low);
            Close = Convert.ToDouble(close);
            Volume = Convert.ToDouble(volume);
            Date = date;
            NumberOfTrades = Convert.ToInt64(numberOfTrades);
        }

        public string Date { get; set; }

        public double Open { get; set; }

        public double High { get; set; }

        public double Low { get; set; }

        public double Close { get; set; }

        public double VWAP { get; set; }

        public long NumberOfTrades { get; set; }

        public double Volume { get; set; }

        public double DeliveryVolume { get; set; }
    }
}
