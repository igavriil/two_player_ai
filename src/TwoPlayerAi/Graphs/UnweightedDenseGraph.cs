using System;
using System.Linq;
using System.Collections.Generic;
using TwoPlayerAi.Utils;

namespace TwoPlayerAi.Graphs
{
    public abstract class UnweightedDenseGraph<T> : IUnweightedGraph<T>, IGraph<T> where T : IEquatable<T>
    {
        protected bool _directed { get; set; }
        protected int _capacity { get; }
        protected int _edgesCount { get; set; }
        protected int _verticesCount { get; set; }
        protected T[] _vertices { get; }
        protected T _firstInsertedNode { get; }
        protected bool[,] _adjacencyMatrix { get; }

        public UnweightedDenseGraph(uint capacity)
        {
            _edgesCount = 0;
            _verticesCount = 0;
            _capacity = (int)capacity;

            _vertices = new T[capacity];
            _adjacencyMatrix = new bool[capacity, capacity];
            _adjacencyMatrix.Populate(rows: capacity, columns: capacity, defaultValue: false);
        }

        public abstract bool AddEdge(T source, T destination);
        
        public abstract bool RemoveEdge(T source, T destination);

        public IEnumerable<IEdge<T>> Edges
        {
            get
            {
                foreach (T vertex in this.Vertices)
                {
                    foreach (IEdge<T> outgoingEdge in this.OutgoingEdges(vertex))
                    {
                        yield return outgoingEdge;
                    }
                }
            }
        }

        public IEnumerable<T> Vertices
        {
            get
            {
                foreach (T vertex in _vertices)
                {
                    if (vertex == null || vertex.Equals(default(T)))
                    {
                        continue;
                    }
                    yield return vertex;
                }
            }
        }

        public IEnumerable<IEdge<T>> OutgoingEdges(T vertex)
        {
            if (!this.HasVertex(vertex))
            {
                throw new KeyNotFoundException("Vertex not found");
            }

            int sourceIndex = Array.IndexOf(_vertices, vertex);

            for (int adjacentIndex = 0; adjacentIndex < _vertices.Length; adjacentIndex++)
            {
                T adjacent = _vertices[adjacentIndex];
                if (this.HasEdge(vertex, adjacent))
                {
                    yield return new UnweightedEdge<T>(
                        vertex,
                        adjacent
                    );
                }
            }
        }

        public IEnumerable<IEdge<T>> IncomingEdges(T vertex)
        {
            if (!this.HasVertex(vertex))
            {
                throw new KeyNotFoundException("Vertex not found");
            }

            int sourceIndex = Array.IndexOf(_vertices, vertex);

            for (int adjacentIndex = 0; adjacentIndex < _vertices.Length; adjacentIndex++)
            {
                T adjacent = _vertices[adjacentIndex];
                if (this.HasEdge(adjacent, vertex))
                {
                    yield return new UnweightedEdge<T>(
                        adjacent,
                        vertex
                    );
                }
            }
        }
      
        public bool HasEdge(T source, T destination)
        {
            int sourceIndex = Array.IndexOf(_vertices, source);
            int destinationIndex = Array.IndexOf(_vertices, destination);
            if (sourceIndex == -1 || destinationIndex == -1)
            {
                return false;
            }
            return _adjacencyMatrix[sourceIndex, destinationIndex];
        }

        public IEdge<T> GetEdge(T source, T destination)
        {
            int sourceIndex = Array.IndexOf(_vertices, source);
            int destinationIndex = Array.IndexOf(_vertices, destination);

            if (sourceIndex == -1)
            {
                throw new KeyNotFoundException("Source Vertex not found");
            }
            if (destinationIndex == -1)
            {
                throw new KeyNotFoundException("Destination Vertex not found");
            }

            return new UnweightedEdge<T>(source, destination);
        }

        public int EdgesCount
        {
            get
            {
                return _edgesCount;
            }
        }

        public bool IsDirected
        {
            get
            {
                return _directed;
            }
        }

        public bool IsWeighted
        {
            get
            {
                return false;
            }
        }

        public int VerticesCount
        {
            get
            {
                return _verticesCount;
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
            if (this.HasVertex(vertex))
            {
                return false;
            }
            if (_verticesCount >= _capacity)
            {
                return false;
            }

            int indexOfDefault = Array.IndexOf(_vertices, default(T));

            if (indexOfDefault == -1)
            {
                _vertices[_verticesCount] = vertex;
            }
            else
            {
                _vertices[indexOfDefault] = vertex;
            }
            _verticesCount++;

            return true;
        }

        public bool RemoveVertex(T vertex)
        {
            if (!this.HasVertex(vertex))
            {
                return false;
            }

            foreach (IEdge<T> outgoingEdge in this.OutgoingEdges(vertex))
            {
                this.RemoveEdge(outgoingEdge.Source, outgoingEdge.Destination);
            }

            foreach (IEdge<T> incomingEdge in this.IncomingEdges(vertex))
            {
                this.RemoveEdge(incomingEdge.Source, incomingEdge.Destination);
            }

            int index = Array.IndexOf(_vertices, vertex);

            _vertices[index] = default(T);
            _verticesCount--;

            return true;
        }


        public int Degree(T vertex)
        {
            if (!this.HasVertex(vertex))
            {
                throw new KeyNotFoundException("Vertex not found");
            }

            return this.Neighbours(vertex).Count();
        }

        public bool HasVertex(T vertex)
        {
            return _vertices.Contains(vertex);
        }

        public IEnumerable<T> Neighbours(T vertex)
        {
            foreach (IEdge<T> outgoingEdge in this.OutgoingEdges(vertex))
            {
                yield return outgoingEdge.Destination;
            }
        }

        public string ToReadable()
        {
            string output = string.Empty;

            for (int i = 0; i < _vertices.Length; ++i)
            {
                if (_vertices[i] == null || _vertices[i].Equals(default(T)))
                {
                    continue;
                }

                var node = (T)_vertices[i];
                var adjacents = string.Empty;

                output = String.Format("{0}\r\n{1}: [", output, node);

                foreach (var adjacentNode in Neighbours(node))
                    adjacents = String.Format("{0}{1},", adjacents, adjacentNode);

                if (adjacents.Length > 0)
                    adjacents = adjacents.TrimEnd(new char[] { ',', ' ' });

                output = String.Format("{0}{1}]", output, adjacents);
            }

            return output;
        }
    }
}