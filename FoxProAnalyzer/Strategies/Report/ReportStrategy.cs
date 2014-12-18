using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using FoxProAnalyzer.Util;

namespace FoxProAnalyzer.Strategies.Report
{
    /// <summary>
    /// Busca los usos de reportes FRX
    /// </summary>
    public class ReportStrategy : BaseStrategy<ReportResult>
    {
        private readonly string output;

        private readonly Dictionary<string, HashSet<string>> references;

        private CsvFile outFile { get; set; }

        public ReportStrategy(string output)
        {
            this.output = output;
            this.references = new Dictionary<string, HashSet<string>>();
            this.outFile = new CsvFile(Path.GetFileNameWithoutExtension(output) + "_1" + Path.GetExtension(output));
        }

        public override void Process(string file)
        {
            var result = new ReportResult { Name = Path.GetFileName(file), Reports = new List<string>() };
            
            var extension = Path.GetExtension(file);
            if (extension == ".prg" || extension == ".h")
            {
                this.Analyze(File.ReadAllText(file), result);
            }
            else
            {
                var processor = new Processor<ReportResult>();
                processor.Process(file, this, result);
            }

            this.outFile.Write(result.Name).Write(result.IsError).Write(result.ErrorMessage);
            result.Reports.ForEach(r => this.outFile.Write(r));
            this.outFile.WriteLine();

            foreach (var report in result.Reports)
            {
                if (!this.references.ContainsKey(report))
                {
                    this.references[report] = new HashSet<string>();
                }

                this.references[report].Add(result.Name);
            }
        }

        public override void Analyze(string content, ReportResult result)
        {
            var lower = content.ToLower();
            var search1 = from Match match in Regex.Matches(lower, @"'r_(\d{3,4})(\.frx)?'")
                          select match.ToString()
                          into item
                          select item.Substring(1, item.Length - 2);

            var search2 = from Match match in Regex.Matches(lower, @"loimprimir\.id\s*=\s*(\d{3,4})")
                          select match.Groups[1].ToString();

            result.Reports =
                search1.Select(x => x.EndsWith(".frx") ? x : x + ".frx")
                    .Union(search2.Select(x => "r_" + (x.Length <= 3 ? "0" + x : x) + ".frx"))
                    .ToList();
        }

        public override void MarkError(ReportResult result, Exception exception)
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
            this.outFile.Dispose();
            this.outFile = new CsvFile(Path.GetFileNameWithoutExtension(output) + "_2" + Path.GetExtension(output));

            foreach (var reference in this.references)
            {
                this.outFile.Write(reference.Key);
                reference.Value.ToList().ForEach(x => this.outFile.Write(x));
                this.outFile.WriteLine();
            }

            this.outFile.Dispose();
        }
    }
}
