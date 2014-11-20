using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FoxProAnalyzer.Processors
{
    public class ProgramProcessor : FileProcessor
    {
        public override bool CanProcess(string filePath)
        {
            var lower = filePath.ToLower();
            return lower.EndsWith(".prg") || lower.EndsWith(".h");
        }

        public override Result Process(string path, bool trackReports = false)
        {
            var result = new Result { Name = Path.GetFileName(path), Path = path };

            if (trackReports)
            {
                result.Reports = new List<string>();
            }

            foreach (string line in File.ReadAllLines(path))
            {
                var vLine = line.Replace("\r\n", "\r").Replace("\t", "");
                if (vLine.Length == 0)
                {
                    result.BlankLines++;
                }
                else
                {
                    if (trackReports)
                    {
                        result.Reports.AddRange(this.TrackReports(vLine));
                    }

                    result.MethodCount += this.Occurs("PROCEDURE ", vLine.ToUpper());
                    result.MethodCount += this.Occurs("FUNCTION ", vLine.ToUpper());

                    // Check for lines beginning with && as comments (bad form but VFP accepts it)
                    // Correctly account for short lines
                    if (vLine.Substring(0, 1) == "*" || (vLine.Length > 2 && vLine.Substring(0, 3) == "*!*") || (vLine.Length > 1 && vLine.Substring(0, 2) == "&&"))
                    {
                        result.CommentLines++;
                    }
                    else
                    {
                        result.CodeLines++;
                    }
                }
            }

            if (trackReports)
            {
                result.Reports = result.Reports.Distinct().ToList();
            }

            return result;
        }
    }
}
