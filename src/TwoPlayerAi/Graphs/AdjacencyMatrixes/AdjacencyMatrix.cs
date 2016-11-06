using System;
using System.Collections.Generic;
using System.Linq;

namespace TwoPlayerAi.Graphs.AdjacencyMatrixes
{
    public abstract class AdjacencyMatrix<T> : IAdjacencyMatrix<T>
        where T : IEquatable<T>
    {
        protected const int DefaultCapacity = 4;
        protected T[] _vertices;
        protected int _verticesCount;
        protected int _edgesCount;
        protected int _size;
        protected abstract void Resize(int capacity);
        public abstract Edge<T> GetEdge(T source, T destination);
        public abstract bool SetEdge(T source, T destination, int value);
        public abstract bool HasEdge(T source, T destination);
        public abstract bool RemoveEdge(T source, T destination);
        public int VerticesCount
        {
            get
            {
                return _verticesCount;
            }
        }

        public int EdgesCount
        {
            get
            {
                return _edgesCount;
            }
        }

        protected void ResizeVertices(int capacity)
        {
             Array.Resize(ref _vertices, capacity);
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

        public bool AddVertex(T element)
        {
            if (this.HasVertex(element))
            {
                return false;
            }
            if (_verticesCount >= _size)
            {
                this.Resize((_size == 0) ? DefaultCapacity : 2 * _size);
                return this.AddVertex(element);
            }

            int indexOfDefault = Array.IndexOf(_vertices, default(T));

            if (indexOfDefault == -1)
            {
                _vertices[_verticesCount] = element;
            }
            else
            {
                _vertices[indexOfDefault] = element;
            }
            _verticesCount++;

            return true;
        }

        public bool RemoveVertex(T element)
        {
            if (!this.HasVertex(element))
            {
                return false;
            }

            int index = Array.IndexOf(_vertices, element);

            _vertices[index] = default(T);
            _verticesCount--;

            return true;
        }

        public bool HasVertex(T element)
        {
            return _vertices.Contains(element);
        }

        public IEnumerable<Edge<T>> Edges
        {
            get
            {
                foreach (T vertex in this.Vertices)
                {
                    foreach (Edge<T> outgoingEdge in this.OutgoingEdges(vertex))
                    {
                        yield return outgoingEdge;
                    }
                }
            }
        }

        public IEnumerable<Edge<T>> OutgoingEdges(T vertex)
        {
            if (!this.HasVertex(vertex))
            {
                throw new KeyNotFoundException();
            }

            int sourceIndex = Array.IndexOf(_vertices, vertex);

            for (int adjacentIndex = 0; adjacentIndex < _vertices.Length; adjacentIndex++)
            {
                T adjacent = _vertices[adjacentIndex];
                if (this.HasEdge(vertex, adjacent))
                {
                    yield return this.GetEdge(vertex, adjacent);
                }
            }
        }

        public IEnumerable<Edge<T>> IncomingEdges(T vertex)
        {
            if (!this.HasVertex(vertex))
            {
                throw new KeyNotFoundException();
            }

            int sourceIndex = Array.IndexOf(_vertices, vertex);

            for (int adjacentIndex = 0; adjacentIndex < _vertices.Length; adjacentIndex++)
            {
                T adjacent = _vertices[adjacentIndex];
                if (this.HasEdge(adjacent, vertex))
                {
                    yield return this.GetEdge(adjacent, vertex);
                }
            }
        }
    }
}