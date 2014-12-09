using System;
using System.IO;

using FoxProAnalyzer.Util;

namespace FoxProAnalyzer.Strategies.Summary
{
    public class SummaryStrategy : BaseStrategy<SummaryResult>
    {
        private CsvFile outFile { get; set; }

        public SummaryStrategy(string output)
        {
            this.outFile = new CsvFile(output);

            this.outFile.WriteLine(
                "Name",
                "Path",
                "Methods",
                "BlankLines",
                "CommentLines",
                "CodeLines",
                "IsError",
                "ErrorMessage");
        }

        public override void Process(string file)
        {
            var result = new SummaryResult { Name = Path.GetFileName(file), Path = file };
            var extension = Path.GetExtension(file);
            if (extension == ".prg" || extension == ".h")
            {
                this.Analyze(File.ReadAllText(file), result);
            }
            else
            {
                var processor = new Processor<SummaryResult>();
                processor.Process(file, this, result);
            }

            this.outFile.WriteLine(
                result.Name,
                result.Path,
                result.MethodCount,
                result.BlankLines,
                result.CommentLines,
                result.CodeLines,
                result.IsError,
                result.ErrorMessage);
        }

        public override void Analyze(string content, SummaryResult result)
        {
            var contentInAllCaps = content.ToUpper();
            result.MethodCount += this.Occurs("PROCEDURE", contentInAllCaps);
            result.MethodCount += this.Occurs("FUNCTION ", contentInAllCaps);

            var m = content.Replace("\r\n", "\r");
            m = m.Replace("\t", "");

            foreach (string s in m.Split(new[] { "\r" }, StringSplitOptions.None))
            {
                if (string.IsNullOrEmpty(s))
                {
                    result.BlankLines++;
                }
                else if (s.Substring(0, 1) == "*" || (s.Length > 2 && s.Substring(0, 3) == "*!*")
                         || (s.Length > 1 && s.Substring(0, 2) == "&&"))
                {
                    result.CommentLines++;
                }
                else
                {
                    result.CodeLines++;
                }
            }
        }

        public override void MarkError(SummaryResult result, Exception exception)
        {
            result.IsError = true;
            result.ErrorMessage = exception.Message;
            result.Exception = exception;
        }

        private int Occurs(string cString, string cExpression)
        {
            int nPos = 0;
            int nOccured = 0;
            do
            {
                //Look for the search string in the expression
                nPos = cExpression.IndexOf(cString, nPos);
                if (nPos < 0)
                {
                    //This means that we did not find the item			
                    break;
                }
                else
                {
                    //Increment the occured counter based on the current mode we are in			
                    nOccured++;
                    nPos++;
                }
            } while (true);
            //Return the number of occurences	
            return nOccured;
        }

        public override void Dispose()
        {
            if (this.outFile != null)
            {
                this.outFile.Dispose();
            }
        }
    }
}
