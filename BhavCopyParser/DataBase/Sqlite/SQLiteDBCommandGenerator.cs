using BhavCopyParser.BhavCopy.EquityBhavCopy;
using BhavCopyParser.DataModels.EquityData;
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
                string commandText = @"CREATE TABLE IF NOT EXISTS '" + tableName + "' (DateInt INTEGER PRIMARY KEY, Date TEXT, Open REAL, High REAL, Low REAL, Close REAL, Volume REAL, NumberOfTrades REAL, VWAP REAL)";
                commands.Add(commandText);
            }
            return commands;
        }

        public List<string> GetInsertCommands(EquityBhavCopyParserOutput inputData)
        {
            List<string> commands = new List<string>();
            foreach (var input in inputData.data)
            {
                string stockSymbol = input.Key;
                List<OHLC> ohlc = input.Value;
                string statement = "INSERT INTO '" + stockSymbol + "' (DateInt, Date, Open, High, Low, Close, Volume, NumberOfTrades, VWAP) VALUES ";
                foreach (var data in ohlc)
                {
                    string valStr = data.Date + ", " + data.Date + ", " + data.Open + ", " + data.High + ", " + data.Low + ", " + data.Close + ", " + data.Volume + ", " + data.NumberOfTrades + ", " + data.VWAP;
                    statement = statement + ",(" + valStr + ")";
                }
                commands.Add(statement);
            }
            return commands;
        }
    }
}
