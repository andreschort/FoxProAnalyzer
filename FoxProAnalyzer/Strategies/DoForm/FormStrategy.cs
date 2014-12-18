using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using FoxProAnalyzer.Util;

namespace FoxProAnalyzer.Strategies.DoForm
{
    /// <summary>
    /// Busca todas las invocaciones de formularios (DO FORM)
    /// </summary>
    public class FormStrategy : BaseStrategy<FormResult>
    {
        private readonly string target;

        private CsvFile outFile { get; set; }

        private Dictionary<string, string> captions { get; set; }

        public FormStrategy(string target, string output)
        {
            this.target = target;
            this.outFile = new CsvFile(output);
            this.captions = new Dictionary<string, string>();

            this.outFile.WriteLine(
                "Caller",
                "Caller Caption",
                "Callee",
                "Callee Caption",
                "Params",
                "FullText",
                "IsError",
                "ErrorMessage");
        }

        public override void Process(string file)
        {
            var result = new FormResult { Name = Path.GetFileName(file), Path = file, Calls = new List<FormCall>() };

            var extension = Path.GetExtension(file);
            if (extension == ".prg" || extension == ".h")
            {
                this.Analyze(File.ReadAllText(file), result);
            }
            else
            {
                var processor = new Processor<FormResult>();
                processor.Process(file, this, result);
            }

            if (file.EndsWith(".scx"))
            {
                result.Caption = FoxUtil.GetProperty(file, "form", "Caption");
                this.captions[result.Name] = result.Caption;
            }

            var basename = Path.GetFileNameWithoutExtension(result.Name);
            
            foreach (var call in result.Calls)
            {
                this.outFile.WriteLine(
                    basename,
                    result.Caption,
                    call.Callee,
                    this.GetCaption(call.Callee + ".scx"),
                    call.Params,
                    call.FullText,
                    result.IsError,
                    result.ErrorMessage);
            }
        }

        private string GetCaption(string callee)
        {
            try
            {
                if (this.captions.ContainsKey(callee))
                {
                    return this.captions[callee];
                }

                var file = Directory.GetFiles(this.target, callee, SearchOption.AllDirectories).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(file))
                {
                    return string.Empty;
                }

                var caption = FoxUtil.GetProperty(file, "form", "Caption");

                this.captions[callee] = caption;

                return caption;
            }
            catch (Exception ex)
            {
                // who cares
            }

            return string.Empty;
        }

        public override void Analyze(string content, FormResult result)
        {
            var stripped = FoxUtil.Strip(content);
            foreach (Match match in Regex.Matches(stripped, @"do\s+form\s+(\S+)(.*)$", RegexOptions.Multiline | RegexOptions.IgnoreCase))
            {
                result.Calls.Add(
                    new FormCall
                        {
                            Callee = match.Groups[1].ToString().Trim(),
                            Params = match.Groups[2].ToString().Trim(),
                            FullText = match.Groups[0].ToString().Trim()
                        });
            }
        }

        public override void MarkError(FormResult result, Exception exception)
        {
            result.IsError = true;
            result.ErrorMessage = exception.Message;
        }

        public override void Dispose()
        {
            this.outFile.Dispose();
        }
    }
}
