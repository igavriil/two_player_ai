using System;
using System.Collections.Generic;

namespace TwoPlayerAi.AdjacencyMatrices
{
    public interface IAdjacencyMatrix<T> where T : IEquatable<T>
    {
        int EdgesCount { get; }
        IEnumerable<Edge<T>> Edges { get; }
        IEnumerable<Edge<T>> OutgoingEdges(T vertex);
        IEnumerable<Edge<T>> IncomingEdges(T vertex);
        Edge<T> GetEdge(T source, T destination);
        bool SetEdge(T source, T destination, int value);
        bool HasEdge(T source, T destination);
        bool RemoveEdge(T source, T destination);
        int VerticesCount { get; }
        IEnumerable<T> Vertices { get; }
        bool AddVertex(T element);
        bool HasVertex(T element);
        bool RemoveVertex(T element);
    }
}