using System;
using System.IO;

namespace FoxProAnalyzer.Util
{
    public class CsvFile : IDisposable
    {
        private readonly StreamWriter writer;

        private const string separator = ";";

        public CsvFile(string path)
        {
            this.writer = new StreamWriter(path);
        }

        public CsvFile WriteLine(params object[] values)
        {
            foreach (var value in values)
            {
                this.writer.Write(value);
                this.writer.Write(separator);
            }

            this.writer.Write(Environment.NewLine);

            return this;
        }

        public CsvFile Write(object value)
        {
            this.writer.Write(value);
            this.writer.Write(separator);

            return this;
        }

        public void Dispose()
        {
            if (this.writer != null)
            {
                this.writer.Close();
            }
        }
    }
}
