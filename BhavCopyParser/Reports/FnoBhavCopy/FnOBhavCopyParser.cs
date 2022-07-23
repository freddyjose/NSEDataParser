using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhavCopyParser.Reports.FnoBhavCopy
{
    public class FnOBhavCopyParser
    {
        public FnOBhavCopyParserOutput GetFnOData(string folder, string date)
        {
            List<FutureRow> futureRows = new List<FutureRow>();
            List<OptionRow> optionRows = new List<OptionRow>();
            string file = GetFnOFileName(date);
            string fileName = Path.Combine(folder, file);
            using (ZipArchive zipFile = ZipFile.Open(fileName, ZipArchiveMode.Read))
            {
                Stream bhavCopyStream = zipFile.Entries.FirstOrDefault().Open();
                using (TextFieldParser csvParser = new TextFieldParser(bhavCopyStream))
                {
                    csvParser.TextFieldType = FieldType.Delimited;
                    csvParser.SetDelimiters(",");
                    string[] headerRow = csvParser.ReadFields();
                    while (!csvParser.EndOfData)
                    {
                        string[] row = csvParser.ReadFields();
                        if (row[0].Substring(0, 3) == "FUT")
                        {
                            FutureRow futureRow = GetFutureRow(row);
                            futureRows.Add(futureRow);
                        }
                        else if (row[0].Substring(0, 3) == "OPT")
                        {
                            OptionRow optionRow = GetOptionRow(row);
                            optionRows.Add(optionRow);
                        }
                    }
                }
            }

            FnOBhavCopyParserOutput retVal = new FnOBhavCopyParserOutput();
            DateTime dateTime;
            DateTime.TryParse(date, out dateTime);
            retVal.Date = dateTime.ToString("yyyyMMdd");
            retVal.FutureRows = futureRows;
            retVal.OptionRows = optionRows;
            return retVal;
        }

        private OptionRow GetOptionRow(string[] row)
        {
            OptionRow retVal = new OptionRow();
            retVal.Symbol = row[1];
            retVal.ExpiryDate = row[2];
            retVal.StrikePrice = Convert.ToDouble(row[3]);
            retVal.PutCall = row[4] == "PE" ? true : false;
            retVal.Open = Convert.ToDouble(row[5]);
            retVal.High = Convert.ToDouble(row[6]);
            retVal.Low = Convert.ToDouble(row[7]);
            retVal.Close = Convert.ToDouble(row[8]);
            retVal.ContractsTraded = Convert.ToInt64(row[10]);
            retVal.ValueTraded = Convert.ToDouble(row[11]) * 100000;
            retVal.AverageContractPrice = retVal.ValueTraded / retVal.ContractsTraded;
            retVal.OI = Convert.ToDouble(row[12]);
            return retVal;
        }

        private FutureRow GetFutureRow(string[] row)
        {
            FutureRow retVal = new FutureRow();
            retVal.Symbol = row[1];
            retVal.ExpiryDate = row[2];
            retVal.Open = Convert.ToDouble(row[5]);
            retVal.High = Convert.ToDouble(row[6]);
            retVal.Low = Convert.ToDouble(row[7]);
            retVal.Close = Convert.ToDouble(row[8]);
            retVal.ContractsTraded = Convert.ToInt64(row[10]);
            retVal.ValueTraded = Convert.ToDouble(row[11]) * 100000;
            retVal.VWAP = retVal.ValueTraded / retVal.ContractsTraded;
            retVal.OI = Convert.ToDouble(row[12]);
            return retVal;
        }

        private string GetFnOFileName(string date)
        {
            DateTime dateTime = DateTime.Parse(date);
            string dateTimeString = dateTime.ToString("ddMMMyyyy").ToUpper();
            string retVal = "fo" + dateTimeString + "bhav.csv.zip";
            return retVal;
        }
    }
}
