using System;
using System.IO;
using System.Text.RegularExpressions;

using FoxProAnalyzer.Util;

namespace FoxProAnalyzer.Strategies.Sql
{
    public class SqlStrategy : BaseStrategy<SqlResult>
    {
        private int plainSqlCount;

        private int storedProceduresCount;

        public override void Process(string file)
        {
            var result = new SqlResult { Name = Path.GetFileName(file) };

            var extension = Path.GetExtension(file);
            if (extension == ".prg" || extension == ".h")
            {
                this.Analyze(File.ReadAllText(file), result);
            }
            else
            {
                var processor = new Processor<SqlResult>();
                processor.Process(file, this, result);
            }
        }

        public override void Analyze(string content, SqlResult result)
        {
            this.plainSqlCount += Regex.Matches(content.ToLower(), @"""\s*select").Count;
            this.storedProceduresCount += Regex.Matches(content.ToLower(), @"u?sp_").Count;
        }

        public override void MarkError(SqlResult result, Exception exception)
        {
            result.IsError = true;
            result.ErrorMessage = exception.Message;
        }

        public override void Dispose()
        {
            
        }

        public override void End()
        {
            Console.Out.WriteLine("Plain queries: {0}", this.plainSqlCount);
            Console.Out.WriteLine("Stored procedures usages: {0}", this.storedProceduresCount);
            Console.In.ReadLine();
            Console.In.ReadLine();
        }
    }
}
