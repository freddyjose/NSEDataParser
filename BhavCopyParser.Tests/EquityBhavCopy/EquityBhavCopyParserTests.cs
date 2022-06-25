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
                    "cm01JUN2022bhav.csv.zip"
                });

        }
    }
}
