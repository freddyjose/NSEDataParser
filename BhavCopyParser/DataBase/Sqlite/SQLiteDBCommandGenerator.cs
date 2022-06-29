using BhavCopyParser.BhavCopy.EquityBhavCopy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhavCopyParser.DataBase.Sqlite
{
    public class SQLiteDBCommandGenerator
    {
        public List<string> GetInitCommands(List<string> tableNames)
        {
            List<string> commands = new List<string>();
            foreach (string tableName in tableNames)
            {
                string commandText = @"CREATE TABLE IF NOT EXISTS " + tableName + " (DateInt INTEGER PRIMARY KEY, Date TEXT, Open REAL, High REAL, Low REAL, Close REAL, Volume REAL, NumberOfTrades REAL, VWAP REAL)";
                commands.Add(commandText);
            }
            return commands;
        }

    }
}
