using BhavCopyParser.DataModels.EquityData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhavCopyParser.BhavCopy.EquityBhavCopy
{
    public class EquityBhavCopyParserOutput
    {
        public List<KeyValuePair<string, List<OHLC>>> data;

        public EquityBhavCopyParserOutput(List<string> stockSymbols)
        {
            data = new List<KeyValuePair<string, List<OHLC>>>();
            foreach (string stockSymbol in stockSymbols)
            {
                data.Add(new KeyValuePair<string, List<OHLC>>(stockSymbol, new List<OHLC>()));
            }
        }
    }
}
