using System;
using System.Collections.Generic;
using TwoPlayerAi.AdjacencyMatrices;

namespace TwoPlayerAi.Graphs
{
    public interface IGraph<T> : IAdjacencyMatrix<T> 
        where T : IEquatable<T>
    {
        bool IsDirected { get; }
        IEnumerable<T> Neighbours(T vertex);
        int Degree(T vertex);
    }
}