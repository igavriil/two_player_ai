using System;

namespace TwoPlayerAi.Search
{
    public interface IHeustisticFunction<T>
        where T : IEquatable<T>
    {
        int Calculate(IProblem<T> problem, T state);
    }
}