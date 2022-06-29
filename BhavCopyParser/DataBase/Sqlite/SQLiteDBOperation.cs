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

        /// <summary>
        /// executes a series of sql commands
        /// </summary>
        /// <param name="commands">list of commands to be executed</param>
        /// <returns></returns>
        public bool ExecuteTransaction(List<string> commands)
        {
            bool success = false;
            using (SqliteConnection dbConn = new SqliteConnection("DataSource=" + path))
            {
                dbConn.Open();
                using (SqliteTransaction transaction = dbConn.BeginTransaction())
                {
                    foreach (string command in commands)
                    {
                        SqliteCommand cmd = new SqliteCommand(command, dbConn, transaction);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    transaction.Commit();
                    success = true;
                }
                dbConn.Close();
            }
            return success;
        }
    }
}
