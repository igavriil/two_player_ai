using System;

namespace TwoPlayerAi.Graphs
{
    public interface IUnweightedGraph<T> where T : IEquatable<T>
    {
        bool AddEdge(T source, T destination);

        bool HasEdge(T source, T destination);
    }
}