using System;

namespace FoxProAnalyzer.Strategies
{
    public interface IStrategy : IDisposable
    {
        void Process(string file);

        void End();
    }
}
