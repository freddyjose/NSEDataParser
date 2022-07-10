using BhavCopyParser.DataBase.Sqlite;
using Microsoft.Data.Sqlite;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

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
            SqliteConnection.ClearAllPools();
            if (res)
                File.Delete("data.db");
        }

        [Test]
        public void ExecuteTransaction_FiveTables_ReturnsTrue()
        {
            SQLiteDBOperation dbOperation = new SQLiteDBOperation("data.db");
            dbOperation.CreateDBFileIfNotExists();
            List<string> commands = new List<string>();
            commands.Add(@"CREATE TABLE IF NOT EXISTS RELIANCE (DateInt INTEGER PRIMARY KEY, Date TEXT, Open REAL, High REAL, Low REAL, Close REAL, Volume REAL, NumberOfTrades REAL, VWAP REAL)");
            commands.Add(@"CREATE TABLE IF NOT EXISTS TCS (DateInt INTEGER PRIMARY KEY, Date TEXT, Open REAL, High REAL, Low REAL, Close REAL, Volume REAL, NumberOfTrades REAL, VWAP REAL)");
            commands.Add(@"CREATE TABLE IF NOT EXISTS HDFC (DateInt INTEGER PRIMARY KEY, Date TEXT, Open REAL, High REAL, Low REAL, Close REAL, Volume REAL, NumberOfTrades REAL, VWAP REAL)");
            commands.Add(@"CREATE TABLE IF NOT EXISTS HDFCBANK (DateInt INTEGER PRIMARY KEY, Date TEXT, Open REAL, High REAL, Low REAL, Close REAL, Volume REAL, NumberOfTrades REAL, VWAP REAL)");
            commands.Add(@"CREATE TABLE IF NOT EXISTS INFY (DateInt INTEGER PRIMARY KEY, Date TEXT, Open REAL, High REAL, Low REAL, Close REAL, Volume REAL, NumberOfTrades REAL, VWAP REAL)");
                        
            bool res = dbOperation.ExecuteTransaction(commands);
            Assert.AreEqual(true, res);

            SqliteConnection.ClearAllPools();
            if (res)
                File.Delete("data.db");
        }
    }
}
