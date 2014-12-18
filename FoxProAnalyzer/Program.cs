using FoxProAnalyzer.Strategies;
using FoxProAnalyzer.Strategies.DoForm;
using FoxProAnalyzer.Strategies.Report;
using FoxProAnalyzer.Strategies.SqlSummary;
using FoxProAnalyzer.Strategies.StoredProcedure;
using FoxProAnalyzer.Strategies.Summary;

namespace FoxProAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();

            if (!CommandLine.Parser.Default.ParseArguments(args, options))
            {
                return;
            }

            IStrategy strategy;
            if (options.TrackReports)
            {
                strategy = new ReportStrategy(options.Output);
            }
            else if (options.SearchSql)
            {
                strategy = new SqlSummaryStrategy(options.Output);
            }
            else if (options.SearchForm)
            {
                strategy = new FormStrategy(options.Target, options.Output);
            }
            else if (options.SearchStoredProcedures)
            {
                strategy = new StoredProcedureStrategy(options.Output);
            }
            else
            {
                strategy = new SummaryStrategy(options.Output);
            }

            var context = new Context(options.Target, strategy);
            context.Execute();
        }
    }
}
