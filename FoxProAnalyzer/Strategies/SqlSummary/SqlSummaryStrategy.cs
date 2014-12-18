using System;
using System.IO;
using System.Text.RegularExpressions;

using FoxProAnalyzer.Util;

namespace FoxProAnalyzer.Strategies.SqlSummary
{
    /// <summary>
    /// Cuenta el numero de consultas SQL y el numero de Store Procedures ejecutados en cada recurso
    /// </summary>
    public class SqlSummaryStrategy : BaseStrategy<SqlSummaryResult>
    {
        private CsvFile outFile { get; set; }

        public SqlSummaryStrategy(string output)
        {
            this.outFile = new CsvFile(output);

            this.outFile.WriteLine(
                "Name",
                "PlainQueryCount",
                "StoredProceduresCount",
                "IsError",
                "ErrorMessage");
        }

        public override void Process(string file)
        {
            var result = new SqlSummaryResult { Name = Path.GetFileName(file) };

            var extension = Path.GetExtension(file);
            if (extension == ".prg" || extension == ".h")
            {
                this.Analyze(File.ReadAllText(file), result);
            }
            else
            {
                var processor = new Processor<SqlSummaryResult>();
                processor.Process(file, this, result);
            }

            this.outFile.WriteLine(
                result.Name,
                result.PlainQueryCount,
                result.StoredProceduresCount,
                result.IsError,
                result.ErrorMessage);
        }

        public override void Analyze(string content, SqlSummaryResult result)
        {
            var stripped = FoxUtil.Strip(content).ToLower();

            result.PlainQueryCount += Regex.Matches(stripped, @"""select\s*\S*").Count;
            result.StoredProceduresCount += Regex.Matches(stripped, @"\su?sp_").Count;
        }

        public override void MarkError(SqlSummaryResult result, Exception exception)
        {
            result.IsError = true;
            result.ErrorMessage = exception.Message;
        }

        public override void Dispose()
        {
            this.outFile.Dispose();
        }

        public override void End()
        {
        }
    }
}
