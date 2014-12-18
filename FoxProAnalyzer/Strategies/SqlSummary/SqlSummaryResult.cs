namespace FoxProAnalyzer.Strategies.SqlSummary
{
    public class SqlSummaryResult
    {
        public string Name { get; set; }

        public int StoredProceduresCount { get; set; }

        public int PlainQueryCount { get; set; }

        public bool IsError { get; set; }

        public string ErrorMessage { get; set; }
    }
}
