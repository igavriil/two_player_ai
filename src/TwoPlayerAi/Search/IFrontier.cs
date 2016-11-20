using System.Collections.Generic;

namespace TwoPlayerAi.Search
{
    public interface IFrontier<T> : IEnumerable<T>
    {
        bool IsEmpty { get; }
        T First { get; }
        T Take();
        void Put(T element);
        void Put(IEnumerable<T> elements);
        void Clear();
    }
}