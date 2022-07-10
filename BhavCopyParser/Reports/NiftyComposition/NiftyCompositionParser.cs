using BhavCopyParser.BhavCopy.FileSystem;
using BhavCopyParser.DataModels.NiftyComposition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhavCopyParser.Reports.NiftyComposition
{
    public class NiftyCompositionParser
    {
        public NiftyCompositionParser(IDirectoryOps @object)
        {
            Object = @object;
        }

        public IDirectoryOps Object { get; }

        public List<NiftyComponents> GetNiftyComponents(string startDate, string endDate, string niftyDataFolder)
        {
            return null;
        }
    }
}
