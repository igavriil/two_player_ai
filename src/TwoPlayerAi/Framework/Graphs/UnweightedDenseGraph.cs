using System;
using System.Linq;
using System.Collections.Generic;
using TwoPlayerAi.Framework.Common;

namespace TwoPlayerAi.Framework.Graphs
{
    public class UnweightedDenseGraph<T> : IUnweightedGraph<T>, IGraph<T> where T : IEquatable<T>
    {
        protected virtual bool _directed { get; }
        protected virtual int _capacity { get; }
        protected virtual int _edgesCount { get; private set; }
        protected virtual int _verticesCount { get; private set; }
        protected virtual T[] _vertices { get; }
        protected virtual T _firstInsertedNode { get; }
        protected virtual bool[,] _adjacencyMatrix { get; }

        public UnweightedDenseGraph(uint capacity, bool directed)
        {
            _edgesCount = 0;
            _verticesCount = 0;
            _capacity = (int)capacity;
            _directed = directed;

            _vertices = new T[capacity];
            _adjacencyMatrix = new bool[capacity, capacity];
            _adjacencyMatrix.Populate(rows: capacity, columns: capacity, defaultValue: false);
        }

        public virtual IEnumerable<IEdge<T>> Edges
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

        public virtual IEnumerable<T> Vertices
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

        public virtual IEnumerable<IEdge<T>> OutgoingEdges(T vertex)
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

        public virtual IEnumerable<IEdge<T>> IncomingEdges(T vertex)
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

        public virtual bool AddEdge(T source, T destination)
        {
            int sourceIndex = Array.IndexOf(_vertices, source);
            int destinationIndex = Array.IndexOf(_vertices, destination);

            if (sourceIndex == -1 || destinationIndex == -1)
            {
                return false;
            }
            else if (!this.IsDirected && this.HasEdge(source, destination))
            {
                return false;
            }
            else if (this.IsDirected && this.HasEdge(source, destination) && this.HasEdge(destination, source))
            {
                return false;
            }

            if (!this.IsDirected)
            {
                _adjacencyMatrix[sourceIndex, destinationIndex] = true;
                _edgesCount++;
            }
            else
            {
                _adjacencyMatrix[sourceIndex, destinationIndex] = true;
                _edgesCount++;
                _adjacencyMatrix[destinationIndex, sourceIndex] = true;
                _edgesCount++;
            }

            return true;
        }

        public virtual bool RemoveEdge(T source, T destination)
        {
            int sourceIndex = Array.IndexOf(_vertices, source);
            int destinationIndex = Array.IndexOf(_vertices, destination);

            if (sourceIndex == -1 || destinationIndex == -1)
            {
                return false;
            }
            else if (!this.IsDirected && !this.HasEdge(source, destination))
            {
                return false;
            }
            else if (this.IsDirected && !this.HasEdge(source, destination) && !this.HasEdge(destination, source))
            {
                return false;
            }

            if (!this.IsDirected)
            {
                _adjacencyMatrix[sourceIndex, destinationIndex] = false;
                _edgesCount--;
            }
            else
            {
                _adjacencyMatrix[sourceIndex, destinationIndex] = false;
                _edgesCount--;
                _adjacencyMatrix[destinationIndex, sourceIndex] = false;
                _edgesCount--;
            }

            return true;
        }

        public virtual bool HasEdge(T source, T destination)
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

        public virtual int EdgesCount
        {
            get
            {
                return _edgesCount;
            }
        }

        public virtual bool IsDirected
        {
            get
            {
                return _directed;
            }
        }

        public virtual bool IsWeighted
        {
            get
            {
                return false;
            }
        }

        public virtual int VerticesCount
        {
            get
            {
                return _verticesCount;
            }
        }

        public virtual void AddVertices(IEnumerable<T> vertices)
        {
            foreach (T vertex in vertices)
            {
                this.AddVertex(vertex);
            }
        }

        public virtual bool AddVertex(T vertex)
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

        public virtual bool RemoveVertex(T vertex)
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


        public virtual int Degree(T vertex)
        {
            if (!this.HasVertex(vertex))
            {
                throw new KeyNotFoundException("Vertex not found");
            }

            return this.Neighbours(vertex).Count();
        }

        public virtual bool HasVertex(T vertex)
        {
            return _vertices.Contains(vertex);
        }

        public virtual IEnumerable<T> Neighbours(T vertex)
        {
            foreach (IEdge<T> outgoingEdge in this.OutgoingEdges(vertex))
            {
                yield return outgoingEdge.Destination;
            }
        }

        public virtual string ToReadable()
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