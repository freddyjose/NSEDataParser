using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhavCopyParser.DataBase.Sqlite
{
    public class SQLiteDBOperation : IDBOperations
    {
        private string path;

        public SQLiteDBOperation(string dbPath)
        {
            path = dbPath;
        }

        public bool CreateDBFileIfNotExists()
        {
            bool result = false;
            try
            {
                if (File.Exists(path))
                    return true;
                SqliteConnectionStringBuilder connStringBuilder = new SqliteConnectionStringBuilder("DataSource=" + path)
                {
                    Mode = SqliteOpenMode.ReadWriteCreate,
                };
                using (SqliteConnection connection = new SqliteConnection(connStringBuilder.ConnectionString))
                {
                    connection.Open();
                    connection.Close();
                }
                result = true;
            }
            catch (Exception ex) { }
            return result;
        }

        public bool ExecuteInsertTransaction(List<string> commands)
        {
            throw new NotImplementedException();
        }

        public bool InitializeDBFile(List<string> tableNames)
        {
            bool success = false;
            using (SqliteConnection dbConn = new SqliteConnection(path))
            {                
                dbConn.Open();
                using (SqliteTransaction transaction = dbConn.BeginTransaction())
                {
                    foreach (string tableName in tableNames)
                    {
                        SqliteCommand cmd = new SqliteCommand();
                        cmd.CommandText = @"CREATE TABLE IF NOT EXISTS '" + tableName + "'(DateInt INTEGER PRIMARY KEY, Date TEXT, Open REAL, High REAL, Low REAL, Close REAL, Volume REAL, NumberOfTrades REAL, VWAP REAL)";
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    success = true;
                }
            }
            return success;
        }
    }
}
