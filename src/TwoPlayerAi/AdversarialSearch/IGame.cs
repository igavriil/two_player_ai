using System;
using System.Collections.Generic;
using TwoPlayerAi.Search;

namespace TwoPlayerAi.AdversarialSearch
{
    public interface IGame<T>
        where T : IEquatable<T>
    {
        T InitialState { get; }
        IPlayer Player(T state);
        IEnumerable<IAction<T>> Actions(T state);
        T Result(T state, IAction<T> action);
        bool TerminalTest(T state);
        int UtilityFunction(T state, IPlayer player);
    }
}