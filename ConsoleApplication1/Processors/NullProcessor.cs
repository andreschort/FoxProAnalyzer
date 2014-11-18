using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication1.Processors
{
    public class NullProcessor : FileProcessor
    {
        public override bool CanProcess(string extension)
        {
            return true;
        }

        public override Result Process(string path, List<string> keywords)
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
