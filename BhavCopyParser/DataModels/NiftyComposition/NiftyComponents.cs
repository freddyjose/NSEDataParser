using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhavCopyParser.DataModels.NiftyComposition
{
    public class NiftyComponents
    {
        public string Date;

        public List<KeyValuePair<string, float>> components = new List<KeyValuePair<string, float>>();
    }
}
