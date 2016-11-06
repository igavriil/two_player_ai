using System;
using System.Collections.Generic;
using TwoPlayerAi.Graphs.AdjacencyMatrixes;

namespace TwoPlayerAi.Graphs
{
    public interface IGraph<T> where T : IEquatable<T>
    {
        bool IsDirected { get; }

        bool IsWeighted { get; }

        int VerticesCount { get; }

        int EdgesCount { get; }

        IEnumerable<T> Vertices { get; }

        IEnumerable<Edge<T>> Edges { get; }

        IEnumerable<Edge<T>> IncomingEdges(T vertex);

        IEnumerable<Edge<T>> OutgoingEdges(T vertex);

        Edge<T> GetEdge(T source, T destination);

        bool RemoveEdge(T source, T destination);

        bool AddVertex(T vertex);

        bool RemoveVertex(T vertex);

        bool HasVertex(T vertex);

        IEnumerable<T> Neighbours(T vertex);

        int Degree(T vertex);

        bool AddEdge(T source, T destination, int weight);

        bool HasEdge(T source, T destination);

        // bool UpdateEdgeWeight(T source, T destination, int weight);
    }
}