using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoxProAnalyzer.Strategies.Sql
{
    public class SqlResult
    {
        public string Name { get; set; }

        public int StoredProceduresCount { get; set; }

        public int PlainQueryCount { get; set; }

        public bool IsError { get; set; }

        public string ErrorMessage { get; set; }
    }
}
