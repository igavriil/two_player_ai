using System;

namespace TwoPlayerAi.Framework.Graphs
{
    public interface IWeightedGraph<T> where T : IEquatable<T>
    {
        bool AddEdge(T source, T destination, int weight);

        bool HasEdge(T source, T destination, int weight);

        bool UpdateEdgeWeight(T source, T destination, int weight);
    }
}