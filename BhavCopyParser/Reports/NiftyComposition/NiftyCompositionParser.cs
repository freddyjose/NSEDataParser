using BhavCopyParser.BhavCopy.FileSystem;
using BhavCopyParser.DataModels.NiftyComposition;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhavCopyParser.Reports.NiftyComposition
{
    public class NiftyCompositionParser
    {
        private IDirectoryOps directoryOps;

        public NiftyCompositionParser(IDirectoryOps DirectoryOps)
        {
            directoryOps = DirectoryOps;
        }

        public List<NiftyComponents> GetNiftyComponents(string startDate, string endDate, string niftyDataFolder)
        {
            List<NiftyComponents> retVal = new List<NiftyComponents>();
            List<string> fileNames = directoryOps.GetListOfFiles(niftyDataFolder, startDate, endDate);
            foreach (string fileName in fileNames)
            {
                string fullFileName = Path.Combine(niftyDataFolder, fileName);
                using (ZipArchive zipFile = ZipFile.Open(fullFileName, ZipArchiveMode.Read))
                {
                    IReadOnlyCollection<ZipArchiveEntry> zippedFiles = zipFile.Entries;
                    ZipArchiveEntry niftyCompositionFile = zippedFiles.First(x => x.Name == "nifty50_mcwb.csv");
                    Stream niftyCompositionStream = niftyCompositionFile.Open();
                    using (TextFieldParser csvParser = new TextFieldParser(niftyCompositionStream))
                    {
                        int currentPos = 0;
                        csvParser.TextFieldType = FieldType.Delimited;
                        csvParser.SetDelimiters(",");
                        string[] firstRow = csvParser.ReadFields();
                        string[] secondRow = csvParser.ReadFields();
                        string[] headerRow = csvParser.ReadFields();
                        NiftyComponents niftyData = new NiftyComponents();
                        for(int i = 0; i < 50; i++)
                        {
                            string[] row = csvParser.ReadFields();
                            string symbol = row[1];
                            string weightageString = row[6];
                            float weightage = float.Parse(weightageString);
                            niftyData.components.Add(symbol, weightage);
                        }
                        retVal.Add(niftyData);
                    }
                }
            }
            return retVal;
        }
    }
}
