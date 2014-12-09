using System;
using System.Collections.Generic;

namespace FoxProAnalyzer.Strategies.Report
{
    public class ReportResult
    {
        public string Name { get; set; }

        public List<string> Reports { get; set; }

        public bool IsError { get; set; }

        public string ErrorMessage { get; set; }
    }
}
