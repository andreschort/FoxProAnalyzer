using System;

namespace FoxProAnalyzer.Strategies
{
    public abstract  class BaseStrategy<T> : IStrategy
    {
        public abstract void Process(string file);

        public abstract void Analyze(string content, T result);

        public abstract void MarkError(T result, Exception exception);

        public abstract void Dispose();

        public virtual void End()
        {
        }
    }
}
