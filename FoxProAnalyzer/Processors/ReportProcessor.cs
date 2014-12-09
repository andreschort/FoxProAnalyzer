using System;
using System.IO;

using FoxProAnalyzer.Util;

namespace FoxProAnalyzer.Processors
{
    public class ReportProcessor : FileProcessor
    {
        public override bool CanProcess(string filePath)
        {
            return filePath.ToLower().EndsWith(".frx");
        }

        public override Result Process(string path, bool trackReports = false)
        {
            var result = new Result { Name = Path.GetFileName(path), Path = path };

            FileIterator it = null;
            try
            {
                it = new FileIterator(path);

                foreach (var content in it.Iterate("expr", "supexpr"))
                {
                    result.MethodCount += this.Occurs("PROCEDURE", content);
                    this.InspectLines(content, result);
                }
            }
            catch (Exception e)
            {
                result.IsError = true;
                result.ErrorMessage = e.Message;
                result.Exception = e;
            }
            finally
            {
                if (it != null)
                {
                    it.Dispose();
                }
            }

            return result;
        }
    }
}
