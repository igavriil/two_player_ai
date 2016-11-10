using System;
using System.Linq;
using System.Collections.Generic;
using TwoPlayerAi.AdjacencyMatrices;

namespace TwoPlayerAi.Graphs
{
    public abstract class Graph<T> : IGraph<T> 
        where T : IEquatable<T>
    {
        protected bool _isWeighted { get; set; }
        protected bool _isDirected { get; set; }
        protected int _capacity { get; }
        protected IAdjacencyMatrix<T> _adjacencyMatrix { get; }

        public Graph(IAdjacencyMatrix<T> adjacencyMatrix)
        {
            _adjacencyMatrix = adjacencyMatrix;
        }

        public abstract bool SetEdge(T source, T destination, int weight);
        
        public abstract bool RemoveEdge(T source, T destination);

        public bool SetEdge(T source, T destination)
        {
            return this.SetEdge(source, destination, 1);
        }
        
        public IEnumerable<Edge<T>> Edges
        {
            get
            {
                foreach (Edge<T> edge in _adjacencyMatrix.Edges)
                {
                    yield return edge;
                }
            }
        }

        public IEnumerable<T> Vertices
        {
            get
            {
                foreach (T vertex in _adjacencyMatrix.Vertices)
                {
                    if (vertex == null || vertex.Equals(default(T)))
                    {
                        continue;
                    }
                    yield return vertex;
                }
            }
        }

        public IEnumerable<Edge<T>> OutgoingEdges(T vertex)
        {
            foreach (Edge<T> edge in _adjacencyMatrix.OutgoingEdges(vertex))
            {
                yield return edge;
            }
        }

        public IEnumerable<Edge<T>> IncomingEdges(T vertex)
        {
            foreach (Edge<T> edge in _adjacencyMatrix.IncomingEdges(vertex))
            {
                yield return edge;
            }
        }
      
        public bool HasEdge(T source, T destination)
        {
            return _adjacencyMatrix.HasEdge(source, destination);
        }

        public Edge<T> GetEdge(T source, T destination)
        {
            return _adjacencyMatrix.GetEdge(source, destination);
        }

        public int EdgesCount
        {
            get
            {
                return _adjacencyMatrix.EdgesCount;
            }
        }

        public int VerticesCount
        {
            get
            {
                return _adjacencyMatrix.VerticesCount;
            }
        }

        public bool IsDirected
        {
            get
            {
                return _isDirected;
            }
        }

        public bool IsWeighted
        {
            get
            {
                return _isWeighted;
            }
        }

        public void AddVertices(IEnumerable<T> vertices)
        {
            foreach (T vertex in vertices)
            {
                this.AddVertex(vertex);
            }
        }

        public bool AddVertex(T vertex)
        {
            return _adjacencyMatrix.AddVertex(vertex);
        }

        public bool RemoveVertex(T vertex)
        {
            if (!this.HasVertex(vertex))
            {
                return false;
            }

            foreach (Edge<T> outgoingEdge in this.OutgoingEdges(vertex))
            {
                this.RemoveEdge(outgoingEdge.Source, outgoingEdge.Destination);
            }

            foreach (Edge<T> incomingEdge in this.IncomingEdges(vertex))
            {
                this.RemoveEdge(incomingEdge.Source, incomingEdge.Destination);
            }
            return _adjacencyMatrix.RemoveVertex(vertex);
        }


        public int Degree(T vertex)
        {
            if (!this.HasVertex(vertex))
            {
                throw new KeyNotFoundException();
            }

            return this.Neighbours(vertex).Count();
        }

        public bool HasVertex(T vertex)
        {
            return _adjacencyMatrix.HasVertex(vertex);
        }

        public IEnumerable<T> Neighbours(T vertex)
        {
            foreach (Edge<T> outgoingEdge in this.OutgoingEdges(vertex))
            {
                yield return outgoingEdge.Destination;
            }
        }
    }
}