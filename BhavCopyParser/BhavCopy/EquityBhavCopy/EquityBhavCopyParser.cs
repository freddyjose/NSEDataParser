using BhavCopyParser.BhavCopy.FileSystem;
using BhavCopyParser.DataModels.EquityData;
using BhavCopyParser.DateParser;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhavCopyParser.BhavCopy.EquityBhavCopy
{
    public class EquityBhavCopyParser
    {
        IDirectoryOps directoryOps;

        public EquityBhavCopyParser(IDirectoryOps dirOps)
        {
            directoryOps = dirOps;
        }

        public EquityBhavCopyParserOutput GetOHLCData(EquityBhavCopyParserInput input)
        {
            EquityBhavCopyParserOutput retVal = new EquityBhavCopyParserOutput(input.StockSymbols);
            List<string> fileNames = directoryOps.GetListOfFiles(input.BhavCopyFolder, input.StartDate, input.EndDate);
            foreach (string fileName in fileNames)
            {
                string fullFileName = Path.Combine(input.BhavCopyFolder, fileName);
                using (ZipArchive zipFile = ZipFile.Open(fullFileName, ZipArchiveMode.Read))
                {
                    Stream bhavCopyStream = zipFile.Entries.FirstOrDefault().Open();
                    using (TextFieldParser csvParser = new TextFieldParser(bhavCopyStream))
                    {
                        int currentPos = 0;
                        csvParser.TextFieldType = FieldType.Delimited;
                        csvParser.SetDelimiters(",");
                        string[] headerRow = csvParser.ReadFields();
                        while (!csvParser.EndOfData)
                        {
                            string[] row = csvParser.ReadFields();
                            string symbolInConsideration = input.StockSymbols[currentPos];
                            if (row[0] == symbolInConsideration)
                            {
                                string dateString = DateConverter.GetDBFriendlyDate(row[10]);
                                if (symbolInConsideration != retVal.data[currentPos].Key)
                                    throw new ArgumentException("Error in inputs");
                                OHLC ohlc = new OHLC(row[2], row[3], row[4], row[5], row[8], dateString, row[11], row[8], row[9]);
                                retVal.data[currentPos].Value.Add(ohlc);
                                currentPos++;
                            }
                            if (currentPos == input.StockSymbols.Count)
                                break;
                        }
                    }
                }
            }
            return retVal;
        }
    }
}
