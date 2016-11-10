using System;
using TwoPlayerAi.AdjacencyMatrices;

namespace TwoPlayerAi.Graphs
{
    public class DirectedDenseGraph<T>: Graph<T> 
        where T : IEquatable<T>
    {
        public DirectedDenseGraph(): base(new AdjacencyDenseMatrix<T>())
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