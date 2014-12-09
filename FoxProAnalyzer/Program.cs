﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using FoxProAnalyzer.Processors;
using FoxProAnalyzer.Strategies;
using FoxProAnalyzer.Strategies.Report;
using FoxProAnalyzer.Strategies.Sql;
using FoxProAnalyzer.Strategies.Summary;

namespace FoxProAnalyzer
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

            var context = new Context(options.Target, GetStrategy(options));
            context.Execute();
            return;

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
                var fileProcessor = processors.FirstOrDefault(proc => proc.CanProcess(options.Target)) ?? nullProcessor;
                ProcessSingleFile(options.Target, fileProcessor, options.TrackReports);
                return;
            }

            var count = 0;
            var errors = new List<Result>();

            var results =
                GetFiles(options)
                    .Select(
                        file =>
                        (processors.FirstOrDefault(proc => proc.CanProcess(file))
                         ?? nullProcessor).Process(file, options.TrackReports));

            var reportReferences = new Dictionary<string, List<string>>();
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
                   .Append(result.ErrorMessage).Append(Separator);

                if (result.Reports != null)
                {
                    foreach (var report in result.Reports)
                    {
                        if (reportReferences.ContainsKey(report))
                        {
                            reportReferences[report].Add(result.Name);
                        }
                        else
                        {
                            reportReferences[report] = new List<string> { result.Name };
                        }
                    }
                }

                csv.Append(Environment.NewLine);
            }

            File.WriteAllText("results.csv", csv.ToString());

            csv = new StringBuilder();

            foreach (var report in reportReferences)
            {
                csv.Append(report.Key).Append(Separator);
                foreach (var reference in report.Value)
                {
                    csv.Append(reference).Append(Separator);
                }
                csv.Append(Environment.NewLine);
            }

            File.WriteAllText("reports.csv", csv.ToString());
            
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

        private static IStrategy GetStrategy(Options options)
        {
            if (options.TrackReports)
            {
                return new ReportStrategy(options.Output);
            }
            
            if (options.SearchSql)
            {
                return new SqlStrategy();
            }

            return new SummaryStrategy(options.Output);
        }

        private static void ProcessSingleFile(string path, FileProcessor processor, bool trackReports)
        {
            var result = processor.Process(path, trackReports);

            Console.WriteLine("Path: {0}", result.Path);
            Console.WriteLine("Methods: {0}", result.MethodCount);
            Console.WriteLine("Blanks: {0}", result.BlankLines);
            Console.WriteLine("Comments: {0}", result.CommentLines);
            Console.WriteLine("Code: {0}", result.CodeLines);

            if (trackReports)
            {
                Console.Out.WriteLine("Reports:");
                foreach (var report in result.Reports)
                {
                    Console.Out.WriteLine(report);
                }
            }

            Console.WriteLine("IsError: {0}", result.IsError);

            if (result.IsError)
            {
                Console.WriteLine("Error: {0}", result.ErrorMessage);
                Console.WriteLine(result.Exception);
            }
        }

        private static IEnumerable<string> GetFiles(Options options)
        {
            var files = Directory.EnumerateFiles(options.Target, "*.*", SearchOption.AllDirectories);

            if (options.Extensions.Any())
            {
                return files.Where(file => options.Extensions.Contains(Path.GetExtension(file).Substring(1)));
            }

            if (options.AllFiles)
            {
                return files;
            }

            var knownExtensions = new List<string> { "scx", "vcx", "mnx", "prg", "h", "frx" };
            return files.Where(file => knownExtensions.Contains(Path.GetExtension(file).Substring(1)));
        }
    }
}
