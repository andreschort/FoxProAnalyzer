using System;

namespace FoxProAnalyzer.Strategies.Summary
{
    public class SummaryResult
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public bool IsError { get; set; }

        public string ErrorMessage { get; set; }

        public Exception Exception { get; set; }

        public int MethodCount { get; set; }

        public int BlankLines { get; set; }

        public int CommentLines { get; set; }

        public int CodeLines { get; set; }
    }
}
