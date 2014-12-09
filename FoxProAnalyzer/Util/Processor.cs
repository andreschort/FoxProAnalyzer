using System;
using System.IO;

using FoxProAnalyzer.Strategies;

namespace FoxProAnalyzer.Util
{
    public class Processor<T>
    {
        public void Process(string path, BaseStrategy<T> strategy, T result)
        {
            FileIterator it = null;
            try
            {
                it = new FileIterator(path);
                foreach (var content in it.Iterate(this.getFields(path)))
                {
                    strategy.Analyze(content, result);
                }
            }
            catch (Exception e)
            {
                strategy.MarkError(result, e);
            }
            finally
            {
                if (it != null)
                {
                    it.Dispose();
                }
            }
        }

        private string[] getFields(string path)
        {
            switch (Path.GetExtension(path))
            {
                case ".scx":
                case ".vcx":
                    return new[] { "methods" };

                case ".mnx":
                    return new[] { "procedure" };
                case ".frx":
                    return new[] { "expr", "supexpr" };
            }

            return null;
        }
    }
}
