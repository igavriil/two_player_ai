using System;
using System.Collections.Generic;

namespace TwoPlayerAi.Framework.Graphs
{
    public interface IGraph<T> where T : IEquatable<T>
    {
        bool IsDirected { get; }

        bool IsWeighted { get; }

        int VerticesCount { get; }

        int EdgesCount { get; }

        IEnumerable<T> Vertices { get; }

        IEnumerable<IEdge<T>> Edges { get; }

        IEnumerable<IEdge<T>> IncomingEdges(T vertex);

        IEnumerable<IEdge<T>> OutgoingEdges(T vertex);

        IEdge<T> GetEdge(T source, T destination);

        bool RemoveEdge(T source, T destination);

        bool AddVertex(T vertex);

        bool RemoveVertex(T vertex);

        bool HasVertex(T vertex);

        IEnumerable<T> Neighbours(T vertex);

        int Degree(T vertex);
    }
}