using System.Collections.Generic;

namespace FoxProAnalyzer.Strategies.StoredProcedure
{
    public class StoredProcedureResult
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public bool IsError { get; set; }

        public string ErrorMessage { get; set; }

        public List<StoredProcedureCall> Calls { get; set; }
    }
}
