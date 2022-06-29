using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhavCopyParser.DataBase
{
    /// <summary>
    /// this interface is supposed to hold all the operations performed on a db
    /// </summary>
    public interface IDBOperations
    {

        bool CreateDBFileIfNotExists();

        bool ExecuteTransaction(List<string> commands);

    }
}
