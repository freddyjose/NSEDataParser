using BhavCopyParser.DataBase.Sqlite;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhavCopyParser.Tests.DataBase.Sqlite
{
    public class SQLiteDBOperationTests
    {
        [Test]
        public void CreateNewDB_DBFileDoesNotExist_ReturnsTrue()
        {
            SQLiteDBOperation dbOperation = new SQLiteDBOperation("data.db");
            dbOperation.CreateDBFileIfNotExists();
        }
    }
}
