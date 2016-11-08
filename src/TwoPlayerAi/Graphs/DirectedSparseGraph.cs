using System;
using TwoPlayerAi.Graphs.AdjacencyMatrices;

namespace TwoPlayerAi.Graphs
{
    public class DirectedSparseGraph<T>: Graph<T> 
        where T : IEquatable<T>
    {
        public DirectedSparseGraph(): base(new AdjacencySparseMatrix<T>())
        {
            _isDirected = true;
        }

        public override bool SetEdge(T source, T destination, int weight)
        {
            return this._adjacencyMatrix.SetEdge(source, destination, weight);
        }

        public override bool RemoveEdge(T source, T destination)
        {
           return this._adjacencyMatrix.RemoveEdge(source, destination);
        }
    }
}