using System;
using System.Linq;
using System.Collections.Generic;

namespace TwoPlayerAi.DataStructures
{
    public class PriorityQueue<T> 
        where T : IComparable<T>
    {
        private IList<T> _priorityQueue;
        private IComparer<T> _comparer;

        public PriorityQueue() : this(Enumerable.Empty<T>(), Comparer<T>.Default) { }

        public PriorityQueue(IEnumerable<T> elements) : this(elements, Comparer<T>.Default){ }

        public PriorityQueue(IComparer<T> comparer) : this(Enumerable.Empty<T>(), comparer) { }

        public PriorityQueue(IEnumerable<T> elements, IComparer<T> comparer)
        {
            _priorityQueue = elements.ToList();
            _comparer = comparer;
            Heapify();
        }

        public int Count
        {
            get
            {
                return _priorityQueue.Count;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return _priorityQueue.Count == 0;
            }
        }

        public void Push(T element)
        {
            int index = Count;
            _priorityQueue.Add(element);
            this.SiftUp(index);
        }

        public T Pop()
        {
            if (Count == 0)
            {
                return default(T);
            }
            else if (Count == 1)
            {
                T element = _priorityQueue[0];
                _priorityQueue.RemoveAt(0);
                return element;
            }
            else
            {
                T element = _priorityQueue[0];
                T lastElement = _priorityQueue[Count - 1];
                _priorityQueue.RemoveAt(Count - 1);
                _priorityQueue[0] = lastElement;
                this.SiftDown(0);
                return element;
            }
        }

        public bool Contains(T element)
        {
            return _priorityQueue.Contains(element);
        }

         public T FirstOrDefault(T element)
        {
            return _priorityQueue.FirstOrDefault(x => x.Equals(element));
        }

        public T Peek()
        {
            return _priorityQueue[0];
        }
        private void Heapify()
        {
            for (int index = (Count / 2); index >= 0; index--)
            {
                this.SiftDown(index);
            }
        }

        private void SiftDown(int currentIndex)
        {
            int leftChildIndex = LeftChildIndex(currentIndex);
            int rightChildIndex = RightChildIndex(currentIndex);
            int smallestIndex = currentIndex;

            if (leftChildIndex < Count && _comparer.Compare(_priorityQueue[smallestIndex], _priorityQueue[leftChildIndex]) > 0)
            {
                smallestIndex = leftChildIndex;
            }
            if (rightChildIndex < Count && _comparer.Compare(_priorityQueue[smallestIndex], _priorityQueue[rightChildIndex]) > 0)
            {
                smallestIndex = rightChildIndex;
            }
            if (smallestIndex != currentIndex)
            {
                this.SwapElements(currentIndex, smallestIndex);
                this.SiftDown(smallestIndex);
            }
        }

        private void SiftUp(int currentIndex)
        {
            if (currentIndex != 0)
            {
                int parentIndex = ParentIndex(currentIndex);
                while (_comparer.Compare(_priorityQueue[currentIndex], _priorityQueue[parentIndex]) < 0)
                {
                    SwapElements(currentIndex, parentIndex);
                    currentIndex = parentIndex;
                    parentIndex = ParentIndex(currentIndex);
                }
            }
        }

        private int ParentIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;
        }

        private int LeftChildIndex(int currentIndex)
        {
            return 2 * currentIndex + 1;
        }

        private int RightChildIndex(int currentIndex)
        {
            return 2 * currentIndex + 2;
        }

        private void SwapElements(int firstIndex, int secondIndex)
        {
            T temp = _priorityQueue[firstIndex];
            _priorityQueue[firstIndex] = _priorityQueue[secondIndex];
            _priorityQueue[secondIndex] = temp;
        }
    }
}