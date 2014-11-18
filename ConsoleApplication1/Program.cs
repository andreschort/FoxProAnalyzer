using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using ConsoleApplication1.Processors;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();

            if (!CommandLine.Parser.Default.ParseArguments(args, options))
            {
                return;
            }

            var csv = new StringBuilder();
            const string Separator = ";";
            csv.Append("Name").Append(Separator)
               .Append("Path").Append(Separator)
               .Append("Methods").Append(Separator)
               .Append("BlankLines").Append(Separator)
               .Append("CommentLines").Append(Separator)
               .Append("CodeLines").Append(Separator)
               .Append("IsError").Append(Separator)
               .Append("ErrorMessage").Append(Separator)
               .Append(Environment.NewLine);

            var processors = new List<FileProcessor>
                                 {
                                     new FormProcessor(),
                                     new MenuProcessor(),
                                     new ProgramProcessor(),
                                     new ReportProcessor()
                                 };
            var nullProcessor = new NullProcessor();

            if (Path.HasExtension(options.Target))
            {
                var fileProcessor = processors.FirstOrDefault(proc => proc.CanProcess(Path.GetExtension(options.Target))) ?? nullProcessor;
                ProcessSingleFile(options.Target, fileProcessor);
                return;
            }

            var count = 0;
            var errors = new List<Result>();

            var files = Directory.EnumerateFiles(options.Target, "*.*", SearchOption.AllDirectories);
            var results = options.Extensions.Any()
                              ? options.Extensions.SelectMany(
                                  ext =>
                                  files.Where(file => file.EndsWith("." + ext))
                                      .Select(path => (processors.FirstOrDefault(p => p.CanProcess(ext)) ?? nullProcessor).Process(path)))
                              : files.Select(
                                  file => (processors.FirstOrDefault(proc => proc.CanProcess(Path.GetExtension(file).Substring(1))) ?? nullProcessor).Process(file));

            foreach (var result in results)
            {
                Console.Out.WriteLine(result.Path);

                count++;

                if (result.IsError)
                {
                    errors.Add(result);
                }

                csv.Append(result.Name).Append(Separator)
                   .Append(result.Path).Append(Separator)
                   .Append(result.MethodCount).Append(Separator)
                   .Append(result.BlankLines).Append(Separator)
                   .Append(result.CommentLines).Append(Separator)
                   .Append(result.CodeLines).Append(Separator)
                   .Append(result.IsError).Append(Separator)
                   .Append(result.ErrorMessage).Append(Separator)
                   .Append(Environment.NewLine);
            }

            File.WriteAllText("results.csv", csv.ToString());
            
            Console.Out.WriteLine("Total: {0}", count);
            Console.Out.WriteLine("Errors: {0}", errors.Count);
            Console.WriteLine();
            Console.WriteLine();

            foreach (var result in errors)
            {
                Console.WriteLine(result.Path);
                Console.WriteLine(result.Exception);
                Console.In.ReadLine();
            }
        }

        private static void ProcessSingleFile(string path, FileProcessor processor)
        {
            var result = processor.Process(path);

            Console.WriteLine("Path: {0}", result.Path);
            Console.WriteLine("Methods: {0}", result.MethodCount);
            Console.WriteLine("Blanks: {0}", result.BlankLines);
            Console.WriteLine("Comments: {0}", result.CommentLines);
            Console.WriteLine("Code: {0}", result.CodeLines);

            Console.WriteLine("IsError: {0}", result.IsError);

            if (result.IsError)
            {
                Console.WriteLine("Error: {0}", result.ErrorMessage);
                Console.WriteLine(result.Exception);
            }
        }
    }
}
