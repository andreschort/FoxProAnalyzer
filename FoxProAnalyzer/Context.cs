using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using FoxProAnalyzer.Strategies;

namespace FoxProAnalyzer
{
    public class Context
    {
        public string Target { get; set; }

        public List<string> Extensions { get; set; }

        public bool ScanAllFiles { get; set; }

        public IStrategy Strategy { get; set; }

        private readonly List<string> knownExtensions = new List<string> { "scx", "vcx", "mnx", "prg", "h", "frx" };

        public Context(string target, IStrategy strategy)
        {
            this.Target = target;
            this.Strategy = strategy;
            this.Extensions = new List<string>();
        }

        public void Execute()
        {
            var count = 0;
            using (this.Strategy)
            {
                foreach (var file in this.GetFiles())
                {
                    Console.Out.WriteLine("File: " + Path.GetFileName(file));
                    count++;
                    this.Strategy.Process(file);
                }

                Console.Out.WriteLine("Total: {0}", count);
                this.Strategy.End();
            }
        }

        private IEnumerable<string> GetFiles()
        {
            var files = Directory.EnumerateFiles(this.Target, "*.*", SearchOption.AllDirectories);

            if (this.Extensions.Any())
            {
                return files.Where(file => this.Extensions.Contains(Path.GetExtension(file).Substring(1)));
            }

            if (this.ScanAllFiles)
            {
                return files;
            }

            return files.Where(file => this.knownExtensions.Contains(Path.GetExtension(file).Substring(1)));
        }
    }
}
