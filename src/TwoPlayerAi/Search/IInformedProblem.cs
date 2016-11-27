using System;

namespace TwoPlayerAi.Search
{
    public interface IInformedProblem<T> : IProblem<T>
        where T : IEquatable<T>
    {
        T GoalState { get; }
    }
}