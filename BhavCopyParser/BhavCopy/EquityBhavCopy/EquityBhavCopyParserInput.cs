using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhavCopyParser.BhavCopy.EquityBhavCopy
{
    public class EquityBhavCopyParserInput
    {
        public List<string> StockSymbols { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string BhavCopyFolder { get; set; }
    }
}
