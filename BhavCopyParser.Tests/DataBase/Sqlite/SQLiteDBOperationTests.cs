using BhavCopyParser.DataBase.Sqlite;
using Microsoft.Data.Sqlite;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
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
            bool res = dbOperation.CreateDBFileIfNotExists();
            Assert.IsTrue(res);
            if (res)
                File.Delete("data.db");
        }

        [Test]
        public void InitializeNewDB_FiveTables_ReturnsTrue()
        {
            SQLiteDBOperation dbOperation = new SQLiteDBOperation("data.db");
            dbOperation.CreateDBFileIfNotExists();
            List<string> tables = new List<string>();
            tables.Add("RELIANCE");
            tables.Add("TCS");
            tables.Add("HDFC");
            tables.Add("HDFCBANK");
            tables.Add("INFY");
            bool res = dbOperation.InitializeDBFile(tables);
            Assert.AreEqual(true, res);

            SqliteConnection.ClearAllPools();
            if (res)
                File.Delete("data.db");
        }
    }
}
