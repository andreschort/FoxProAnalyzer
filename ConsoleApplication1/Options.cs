using System.Collections.Generic;

using CommandLine;
using CommandLine.Text;

namespace ConsoleApplication1
{
    public class Options
    {
        [Option('t', "target", HelpText = "The target file or folder")]
        public string Target { get; set; }

        [OptionList('e', "extensions", Separator = ',', HelpText = "List of file extensions to search")]
        public IList<string> Extensions { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
        }

        [ParserState]
        public IParserState LastParserState { get; set; }
    }
}
