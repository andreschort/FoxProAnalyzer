using System.Collections.Generic;

namespace FoxProAnalyzer.Strategies.DoForm
{
    public class FormResult
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public List<FormCall> Calls { get; set; }

        public bool IsError { get; set; }

        public string ErrorMessage { get; set; }

        public string Caption { get; set; }
    }
}
