using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhavCopyParser.Reports.FnoBhavCopy
{
    public class OptionRow
    {
        public string Symbol;

        public string ExpiryDate;

        public double StrikePrice;

        public bool PutCall;

        public double Open;

        public double High;

        public double Low;

        public double Close;

        public long ContractsTraded;

        public double ValueTraded;

        public double AverageContractPrice;

        public double OI;
    }
}
