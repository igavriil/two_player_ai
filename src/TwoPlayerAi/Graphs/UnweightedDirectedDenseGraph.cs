using System;

namespace TwoPlayerAi.Graphs
{
    public class UnweightedDirectedDenseGraph<T>: UnweightedDenseGraph<T> 
        where T : IEquatable<T>
    {
        public UnweightedDirectedDenseGraph() : base()
        {
            _directed = true;
        }

        public override bool AddEdge(T source, T destination, int weight)
        {
            return this._adjacencyMatrix.SetEdge(source, destination, weight);
        }

        public override bool RemoveEdge(T source, T destination)
        {
           return this._adjacencyMatrix.RemoveEdge(source, destination);
        }
    }
}