using System.IO;

namespace FoxProAnalyzer.Processors
{
    public class NullProcessor : FileProcessor
    {
        public override bool CanProcess(string filePath)
        {
            return true;
        }

        public override Result Process(string path, bool trackReports = false)
        {
            return new Result
                       {
                           Name = Path.GetFileName(path),
                           Path = path,
                           IsError = true,
                           ErrorMessage = "No processor available"
                       };
        }
    }
}
