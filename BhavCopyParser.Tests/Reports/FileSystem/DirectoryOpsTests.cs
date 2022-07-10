using BhavCopyParser.BhavCopy.FileSystem;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BhavCopyParser.Tests.Reports.FileSystem
{
    public class DirectoryOpsTests
    {
        [Test]
        public void GetListOfFiles_SeparateDates_ReturnsListOfFiles()
        {
            DirectoryOps OUT = new DirectoryOps();
            List<string> result = OUT.GetListOfFiles(@"DataFolder\EquityBhavCopy", "22-06-2022", "24-06-2022");
            Assert.AreEqual(3, result.Count);
            Assert.IsTrue(result.First().Contains("22JUN2022"));
            Assert.IsTrue(result.Last().Contains("24JUN2022"));
        }
    }
}
