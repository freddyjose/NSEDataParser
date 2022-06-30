
namespace BhavCopyParser.DataModels.EquityData
{
    public class OHLC
    {
        public OHLC(string open, string high, string low, string close, string volume, string date, string numberOfTrades, string tradedQty, string tradedVal)
        {
            Open = Convert.ToDouble(open);
            High = Convert.ToDouble(high);
            Low = Convert.ToDouble(low);
            Close = Convert.ToDouble(close);
            Volume = Convert.ToDouble(volume);
            Date = date;
            NumberOfTrades = Convert.ToInt64(numberOfTrades);
            VWAP = Convert.ToDouble(tradedVal) / Convert.ToUInt32(tradedQty);
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
