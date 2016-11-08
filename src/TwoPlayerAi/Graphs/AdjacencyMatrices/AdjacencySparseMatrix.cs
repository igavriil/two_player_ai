using System;
using System.Collections.Generic;

namespace TwoPlayerAi.Graphs.AdjacencyMatrices
{
    public class AdjacencySparseMatrix<T> : AdjacencyMatrix<T>, IAdjacencyMatrix<T> 
        where T : IEquatable<T>
    {
        protected Dictionary<int, Dictionary<int, int>> _dictionary;
        public AdjacencySparseMatrix()
        {
            _verticesCount = 0;
            _vertices =  Array.Empty<T>();
            _dictionary = new Dictionary<int, Dictionary<int, int>>();
            _size = 0;
        }

        protected override void Resize(int capacity)
        {
            this.ResizeVertices(capacity);
            _size = capacity;
        }

        public override Edge<T> GetEdge(T source, T destination)
        {
            int sourceIndex = Array.IndexOf(_vertices, source);
            int destinationIndex = Array.IndexOf(_vertices, destination);

            if (sourceIndex == -1)
            {
                throw new KeyNotFoundException();
            }
            if (destinationIndex == -1)
            {
                throw new KeyNotFoundException();
            }

            Dictionary<int, int> columns;
            if (_dictionary.TryGetValue(sourceIndex, out columns))
            {
                int value = default(int);
                if (columns.TryGetValue(destinationIndex, out value))
                {
                    return new Edge<T>(
                        source,
                        destination,
                        value
                    );
                }
            }
            return new Edge<T>(
                        source,
                        destination,
                        default(int)
                    );
        }

        public override bool SetEdge(T source, T destination, int value)
        {
            int sourceIndex = Array.IndexOf(_vertices, source);
            int destinationIndex = Array.IndexOf(_vertices, destination);

            if (sourceIndex == -1 || destinationIndex == -1)
            {
                return false;
            }
            else if (this.HasEdge(source, destination))
            {
                return false;
            }

            if (value.Equals(default(int)))
            {
                this.RemoveEdge(source, destination);
            }
            else
            {
                Dictionary<int, int> columns;
                if (!_dictionary.TryGetValue(sourceIndex, out columns))
                {
                    columns = new Dictionary<int, int>();
                    _dictionary.Add(sourceIndex, columns);
                }
                columns[destinationIndex] = value;
                _edgesCount++;
            }

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
            else if (!this.HasEdge(source, destination))
            {
                return false;
            }

            Dictionary<int, int> columns;
            if (_dictionary.TryGetValue(sourceIndex, out columns))
            {
                columns.Remove(destinationIndex);
                _edgesCount--;
                if (columns.Count == 0)
                {
                    _dictionary.Remove(sourceIndex);
                }
            }
            return true;
        }

        public override bool HasEdge(T source, T destination)
        {
            int sourceIndex = Array.IndexOf(_vertices, source);
            int destinationIndex = Array.IndexOf(_vertices, destination);
            if (sourceIndex == -1 || destinationIndex == -1)
            {
                return false;
            }

            Dictionary<int, int> columns;
            if (_dictionary.TryGetValue(sourceIndex, out columns))
            {
                int value = default(int);
                if (columns.TryGetValue(destinationIndex, out value))
                {
                    return value != default(int);
                }
            }
            return false;
        }
    }
}