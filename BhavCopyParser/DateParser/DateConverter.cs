using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhavCopyParser.DateParser
{
    public class DateConverter
    {
        public static string GetDBFriendlyDate(string input)
        {
            DateTime inputDate = new DateTime();
            DateTime.TryParseExact(input, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out inputDate);
            return inputDate.ToString("yyyy-MM-dd");
        }
    }
}
