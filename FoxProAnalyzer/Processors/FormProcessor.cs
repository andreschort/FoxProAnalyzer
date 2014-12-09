using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using FoxProAnalyzer.Util;

namespace FoxProAnalyzer.Processors
{
    public class FormProcessor : FileProcessor
    {
        public override bool CanProcess(string filePath)
        {
            var lower = filePath.ToLower();
            return lower.EndsWith(".scx") || lower.EndsWith(".vcx");
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
                foreach (var content in it.Iterate("methods"))
                {
                    if (trackReports)
                    {
                        result.Reports.AddRange(this.TrackReports(content));
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
