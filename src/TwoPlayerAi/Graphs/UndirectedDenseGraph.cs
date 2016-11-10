using System;
using TwoPlayerAi.AdjacencyMatrices;

namespace TwoPlayerAi.Graphs
{
    public class UndirectedDenseGraph<T>: Graph<T> 
        where T : IEquatable<T>
    {
        public UndirectedDenseGraph(): base(new AdjacencyDenseMatrix<T>())
        {
            _isDirected = false;
        }

        public override bool SetEdge(T source, T destination, int weight)
        {
            return this._adjacencyMatrix.SetEdge(source, destination, weight) && this._adjacencyMatrix.SetEdge(destination, source, weight);
        }

        public override bool RemoveEdge(T source, T destination)
        {
           return this._adjacencyMatrix.RemoveEdge(source, destination) && this._adjacencyMatrix.RemoveEdge(destination, source);
        }
    }
}