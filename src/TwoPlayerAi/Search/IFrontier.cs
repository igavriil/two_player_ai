using System;

namespace TwoPlayerAi.Search
{
    public interface IFrontier<T> where T : IState
    {
        void Add(T element);

        T Remove();
    }
}