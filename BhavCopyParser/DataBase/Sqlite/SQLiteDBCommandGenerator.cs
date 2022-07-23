using BhavCopyParser.DataModels.EquityData;
using BhavCopyParser.DataModels.NiftyComposition;
using BhavCopyParser.Reports.BhavCopy.EquityBhavCopy;
using BhavCopyParser.Reports.FnoBhavCopy;

namespace BhavCopyParser.DataBase.Sqlite
{
    public class SQLiteDBCommandGenerator
    {
        public List<string> GetInitCommandsForEquity(List<string> tableNames)
        {
            List<string> commands = new List<string>();
            foreach (string tableName in tableNames)
            {
                string commandText = @"CREATE TABLE IF NOT EXISTS '" + tableName + "' (DateInt INTEGER PRIMARY KEY, Date TEXT, Open REAL, High REAL, Low REAL, Close REAL, Volume REAL, NumberOfTrades REAL, VWAP REAL)";
                commands.Add(commandText);
            }
            return commands;
        }

        public List<string> GetInsertCommandsForEquity(EquityBhavCopyParserOutput inputData)
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
        
        public List<string> GetInsertCommandsForNiftyComposition(List<NiftyComponents> niftyComponents)
        {
            List<string> commands = new List<string>();
            foreach (NiftyComponents niftyComponent in niftyComponents)
            {
                string createStatement = @"CREATE TABLE IF NOT EXISTS '" + niftyComponent.Date + "'(Id INTEGER PRIMARY KEY, Symbol TEXT, Weightage REAL)";
                commands.Add(createStatement);
                string insertStatement = "INSERT INTO '" + niftyComponent.Date + "' (Symbol, Weightage) VALUES ";
                List<KeyValuePair<string, float>> components = niftyComponent.components;
                foreach (KeyValuePair<string, float> component in components)
                {
                    string valStr = component.Key + ", " + component.Value;
                    insertStatement = insertStatement + ",(" + valStr + ")";
                }                
                commands.Add(insertStatement);
            }
            return commands;
        }

        public List<string> GetInsertCommandsForOptions(FnOBhavCopyParserOutput fnoBhavCopyParserOutput)
        {
            List<string> commands = new List<string>();
            string createCommand = @"CREATE TABLE IF NOT EXISTS " + fnoBhavCopyParserOutput.Date;
            createCommand += " (Id INTEGER PRIMARY KEY, Symbol TEXT, ExpiryDate TEXT, StrkePrice REAL, Put INTEGER, Open REAL, High REAL, Low REAL, Close REAL, Volume REAL, TradedContracts REAL, AvgContractPrice REAL)";
            commands.Add(createCommand);
            string statement = "INSERT INTO '" + fnoBhavCopyParserOutput.Date + "' (Symbol, ExpiryDate, StrkePrice, Put, Open, High, Low, Close, Volume, TradedContracts, AvgContractPrice) VALUES ";
            foreach (OptionRow optionRow in fnoBhavCopyParserOutput.OptionRows)
            {
                string valStr = optionRow.Symbol + ", " + optionRow.ExpiryDate + ", ";
                valStr += optionRow.PutCall?"1":"0" + ", " + optionRow.Open + ", " + optionRow.High + ", " + optionRow.Low + ", " + optionRow.Close + ", " + optionRow.ValueTraded + ", " + optionRow.ContractsTraded + ", " + optionRow.AverageContractPrice;
                statement = statement + ",(" + valStr + ")";
            }
            commands.Add(statement);
            return commands;
        }

    }
}
