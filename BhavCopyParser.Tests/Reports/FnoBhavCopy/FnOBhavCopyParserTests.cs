using BhavCopyParser.Reports.FnoBhavCopy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhavCopyParser.Tests.Reports.FnoBhavCopy
{
    public class FnOBhavCopyParserTests
    {
        [Test]
        public void GetOHLCData_SingleSymbol_ReturnsSingleSymbolWithASingleRow()
        {
            FnOBhavCopyParser OUT = new FnOBhavCopyParser();
            FnOBhavCopyParserOutput res = OUT.GetFnOData(@"DataFolder\FnOBhavCopy", "14JUN2022");
            Assert.AreEqual("20220614", res.Date);
            Assert.AreEqual(64073, res.OptionRows.Count + res.FutureRows.Count);
            
            OptionRow testOptionRow = res.OptionRows.First();
            Assert.AreEqual("BANKNIFTY", testOptionRow.Symbol);
            Assert.AreEqual("16-Jun-2022", testOptionRow.ExpiryDate);
            Assert.AreEqual(29100, testOptionRow.StrikePrice);
            Assert.IsFalse(testOptionRow.PutCall);
            Assert.AreEqual(4117.2, testOptionRow.Open);
            Assert.AreEqual(4403.5, testOptionRow.High);
            Assert.AreEqual(4094.4, testOptionRow.Low);
            Assert.AreEqual(4225.65, testOptionRow.Close);
            Assert.AreEqual(15, testOptionRow.ContractsTraded);
            Assert.AreEqual(12494000, testOptionRow.ValueTraded);
            Assert.AreEqual(900, testOptionRow.OI);

            FutureRow testFutRow = res.FutureRows.First();
            Assert.AreEqual("BANKNIFTY", testFutRow.Symbol);
            Assert.AreEqual("30-Jun-2022", testFutRow.ExpiryDate);
            Assert.AreEqual(33390, testFutRow.Open);
            Assert.AreEqual(33701.05, testFutRow.High);
            Assert.AreEqual(33185.15, testFutRow.Low);
            Assert.AreEqual(33377.05, testFutRow.Close);
            Assert.AreEqual(163523, testFutRow.ContractsTraded);
            Assert.AreEqual(136583121000, testFutRow.ValueTraded);
            Assert.AreEqual(2719825, testFutRow.OI);
        }
    }
}
