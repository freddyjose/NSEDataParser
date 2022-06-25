using BhavCopyParser.BhavCopy.EquityBhavCopy;
using BhavCopyParser.BhavCopy.FileSystem;
using Moq;
using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhavCopyParser.Tests.EquityBhavCopy
{
    public class EquityBhavCopyParserTests
    {
        [Test]
        public void GetOHLCData_SingleSymbol_ReturnsSingleSymbolWithASingleRow()
        {
            Mock<IDirectoryOps> fakeDirectoryOps = new Mock<IDirectoryOps>();
            fakeDirectoryOps.Setup(x => x.GetListOfFiles(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new List<string>
                {
                    "cm24JUN2022bhav.csv.zip"
                });

            EquityBhavCopyParserInput input = new EquityBhavCopyParserInput();
            input.BhavCopyFolder = @"DataFolder\EquityBhavCopy";
            input.StartDate = "2022-06-23";
            input.EndDate = "2022-06-24";
            input.StockSymbols = new List<string>();
            input.StockSymbols.Add("RELIANCE");

            EquityBhavCopyParser OUT = new EquityBhavCopyParser(fakeDirectoryOps.Object);
            EquityBhavCopyParserOutput result = OUT.GetOHLCData(input);
            Assert.AreEqual("RELIANCE", result.data[0].Key);
            Assert.AreEqual(2480, result.data[0].Value[0].Open);
            Assert.AreEqual(2511, result.data[0].Value[0].High);
            Assert.AreEqual(2468, result.data[0].Value[0].Low);
            Assert.AreEqual(2500.05, result.data[0].Value[0].Close);
            Assert.AreEqual("2022-06-24", result.data[0].Value[0].Date);
            Assert.AreEqual(6571866, result.data[0].Value[0].Volume);
            Assert.AreEqual(258066, result.data[0].Value[0].NumberOfTrades);
        }
    }
}
