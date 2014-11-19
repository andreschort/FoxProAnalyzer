using System.Collections.Generic;

using CommandLine;
using CommandLine.Text;

namespace FoxProAnalyzer
{
    public class Options
    {
        [Option('t', "target", HelpText = "The target file or folder")]
        public string Target { get; set; }

        [OptionList('e', "extensions", Separator = ',', HelpText = "List of file extensions to search", DefaultValue = new string[]{})]
        public IList<string> Extensions { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
        }

        [Option('r', "reports", HelpText = "Search for report references inside files.")]
        public bool TrackReports { get; set; }

        [Option('a', "all", HelpText = "Search inside all files, not just the ones I know.")]
        public bool AllFiles { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }
    }
}
