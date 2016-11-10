using System;
using System.Collections.Generic;

namespace TwoPlayerAi.AdjacencyMatrices
{
    public class AdjacencyDenseMatrix<T> : AdjacencyMatrix<T>, IAdjacencyMatrix<T>
        where T : IEquatable<T>
    {
        protected int[,] _array;

        public AdjacencyDenseMatrix()
        {
            _verticesCount = 0;
            _vertices =  Array.Empty<T>();
            _array = new int[0,0];
            _size = 0;
        }

        protected override void Resize(int capacity)
        {
            this.ResizeArray(capacity);
            this.ResizeVertices(capacity);
            _size = capacity;
        }

        private void ResizeArray(int capacity)
        {
            int[,] resizedArray = new int[capacity, capacity];
            int minX = Math.Min(_array.GetLength(0), resizedArray.GetLength(0));
            int minY = Math.Min(_array.GetLength(1), resizedArray.GetLength(1));

            for (int i = 0; i < minY; ++i)
            {
                 Array.Copy(_array, i * _array.GetLength(0), resizedArray, i * resizedArray.GetLength(0), minX);
            }
            _array = resizedArray;
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

            return new Edge<T>(
                        source,
                        destination,
                        _array[sourceIndex, destinationIndex]
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
                _array[sourceIndex, destinationIndex] = value;
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

            _array[sourceIndex, destinationIndex] = default(int);
            _edgesCount--;

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
            return _array[sourceIndex, destinationIndex] != default(int);
        }
    }
}