namespace BhavCopyParser.BhavCopy.FileSystem
{
    public interface IDirectoryOps
    {
        List<string> GetListOfFiles(string bhavCopyFolder, string startDate, string endDate);
    }
}