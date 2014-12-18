using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

using FoxProAnalyzer.Util;

namespace FoxProAnalyzer.Strategies.StoredProcedure
{
    public class StoredProcedureStrategy : BaseStrategy<StoredProcedureResult>
    {
        private CsvFile outFile { get; set; }

        public StoredProcedureStrategy(string output)
        {
            this.outFile = new CsvFile(output);

            this.outFile.WriteLine(
                "Name",
                "Path",
                "Stored Procedure name",
                "IsError",
                "ErrorMessage");
        }

        public override void Process(string file)
        {
            var result = new StoredProcedureResult { Name = Path.GetFileName(file), Path = file, Calls = new List<StoredProcedureCall>() };

            var extension = Path.GetExtension(file);
            if (extension == ".prg" || extension == ".h")
            {
                this.Analyze(File.ReadAllText(file), result);
            }
            else
            {
                var processor = new Processor<StoredProcedureResult>();
                processor.Process(file, this, result);
            }

            foreach (var call in result.Calls)
            {
                this.outFile.WriteLine(
                    result.Name,
                    result.Path,
                    call.Name,
                    result.IsError,
                    result.ErrorMessage);
            }
        }

        public override void Analyze(string content, StoredProcedureResult result)
        {
            var stripped = FoxUtil.Strip(content);
            foreach (Match match in Regex.Matches(stripped, @"\s*u?sp_\S*", RegexOptions.Multiline | RegexOptions.IgnoreCase))
            {
                result.Calls.Add(
                    new StoredProcedureCall
                        {
                            Name = match.ToString().Trim('\r', '\n', '"', ' '),
                        });
            }
        }

        public override void MarkError(StoredProcedureResult result, Exception exception)
        {
            result.IsError = true;
            result.ErrorMessage = exception.Message;
        }

        public override void Dispose()
        {
            this.outFile.Dispose();
        }
    }
}
