using System.Globalization;

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
