using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FoxProAnalyzer.Processors
{
    public class MenuProcessor : FileProcessor
    {
        public override bool CanProcess(string filePath)
        {
            return filePath.ToLower().EndsWith(".mnx");
        }

        public override Result Process(string path, bool trackReports = false)
        {
            var result = new Result { Name = Path.GetFileName(path), Path = path };

            if (trackReports)
            {
                result.Reports = new List<string>();
            }

            FileIterator it = null;
            try
            {
                it = new FileIterator(path);

                foreach (var content in it.Iterate("procedure"))
                {
                    if (trackReports)
                    {
                        this.TrackReports(content);
                    }

                    result.MethodCount += this.Occurs("PROCEDURE", content);
                    this.InspectLines(content, result);
                }

                if (trackReports)
                {
                    result.Reports = result.Reports.Distinct().ToList();
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
