using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhavCopyParser.BhavCopy.FileSystem
{
    public class DirectoryOps : IDirectoryOps
    {
        /// <summary>
        /// gets the list of cm bhav copy files from a given folder including both the start and end dates.
        /// todo : add a logic to verify the files and throw up a list of missing files
        /// </summary>
        /// <param name="bhavCopyFolder"></param>
        /// <param name="startDateString"></param>
        /// <param name="endDateString"></param>
        /// <returns></returns>
        public List<string> GetListOfFiles(string bhavCopyFolder, string startDateString, string endDateString)
        {
            string[] fileNames = Directory.GetFiles(bhavCopyFolder);
            List<KeyValuePair<DateTime, string>> indexedFileNames = IndexFileNames(fileNames, "cm", "bhav.csv.zip");
            DateTime startDate = DateTime.Parse(startDateString);
            DateTime endDate = DateTime.Parse(endDateString);
            List<string> retVal = new List<string>();
            foreach (KeyValuePair<DateTime, string> indexedFileName in indexedFileNames)
            {
                if(indexedFileName.Key >= startDate && indexedFileName.Key <= endDate)
                    retVal.Add(indexedFileName.Value);
            }
            return retVal;
        }

        private List<KeyValuePair<DateTime, string>> IndexFileNames(string[] fileNames, string prefix, string suffix)
        {
            List<KeyValuePair<DateTime, string>> retVal = new List<KeyValuePair<DateTime, string>>();
            foreach (string fileName in fileNames)
            {
                string fileNameSansDir = Path.GetFileName(fileName);
                string dateTimeString = fileNameSansDir.Substring(prefix.Length, fileNameSansDir.Length - suffix.Length - prefix.Length);
                DateTime dateTime = DateTime.ParseExact(dateTimeString, "ddMMMyyyy", CultureInfo.InvariantCulture);
                retVal.Add(new KeyValuePair<DateTime, string>(dateTime, fileName));
            }
            return retVal;
        }
    }
}
