using System;
using System.Collections.Generic;

namespace TwoPlayerAi.Search
{
    public interface IProblem<T>
        where T : IEquatable<T>
    {
        T InitialState { get; }
        T GoalState { get; }
        IEnumerable<IAction<T>> Actions(T state);
        T Transition(T state, IAction<T> action);
        bool GoalTest(T state);
        int StepCost(T state, IAction<T> action);
    }
}