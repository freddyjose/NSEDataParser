using BhavCopyParser.BhavCopy.FileSystem;
using BhavCopyParser.DataModels.NiftyComposition;
using BhavCopyParser.Reports.NiftyComposition;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhavCopyParser.Tests.Reports.NiftyComposition
{
    public class NiftyCompositionParserTests
    {
        [Test]
        public void GetNiftyComposition_OneMonthData_ReturnsCorrectComposition()
        {
            Mock<IDirectoryOps> fakeDirectoryOps = new Mock<IDirectoryOps>();
            fakeDirectoryOps.Setup(x => x.GetListOfFiles(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new List<string>
                {
                    "mcwb_jun22.zip"
                });
            NiftyCompositionParser OUT = new NiftyCompositionParser(fakeDirectoryOps.Object);
            List<NiftyComponents> result = OUT.GetNiftyComponents("jun22", "jun22", @"DataFolder\NiftyComposition");
            Assert.AreEqual(0.7, result[0].components["ADANIPORTS"], 0.01);
            Assert.AreEqual(0.54, result[0].components["APOLLOHOSP"], 0.01);
        }
    }
}
