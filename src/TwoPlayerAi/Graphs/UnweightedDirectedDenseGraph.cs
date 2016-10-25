using System;

namespace TwoPlayerAi.Graphs
{
    public class UnweightedDirectedDenseGraph<T>: UnweightedDenseGraph<T> 
        where T : IEquatable<T>
    {
        public UnweightedDirectedDenseGraph(uint capacity) : base(capacity)
        {
            _directed = true;
        }
        public override bool AddEdge(T source, T destination)
        {
            int sourceIndex = Array.IndexOf(_vertices, source);
            int destinationIndex = Array.IndexOf(_vertices, destination);

            if (sourceIndex == -1 || destinationIndex == -1)
            {
                return false;
            }
            else if (this.HasEdge(source, destination) && this.HasEdge(destination, source))
            {
                return false;
            }

            _adjacencyMatrix[sourceIndex, destinationIndex] = true;
            _edgesCount++;
            _adjacencyMatrix[destinationIndex, sourceIndex] = true;
            _edgesCount++;

            return true;
        }

        public override bool RemoveEdge(T source, T destination)
        {
            int sourceIndex = Array.IndexOf(_vertices, source);
            int destinationIndex = Array.IndexOf(_vertices, destination);

            if (sourceIndex == -1 || destinationIndex == -1)
            {
                return false;
            }
            else if (!this.HasEdge(source, destination) && !this.HasEdge(destination, source))
            {
                return false;
            }

            _adjacencyMatrix[sourceIndex, destinationIndex] = false;
            _edgesCount--;
            _adjacencyMatrix[destinationIndex, sourceIndex] = false;
            _edgesCount--;

            return true;
        }
    }
}