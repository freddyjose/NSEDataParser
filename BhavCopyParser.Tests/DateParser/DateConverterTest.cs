using BhavCopyParser.DateParser;
using NUnit.Framework;

namespace BhavCopyParser.Tests.DateParser
{
    public class DateConverterTests
    {
        [Test]
        public void DateConverter_BhavCopyInputs_GetsEasilySortableString()
        {
            string output = DateConverter.GetDBFriendlyDate("01-JUN-2022");
            Assert.AreEqual("2022-06-01", output);
        }
    }
}
