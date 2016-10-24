using System;
using Xunit;
using System.Collections.Generic;
using TwoPlayerAi.DataStructures;

namespace TwoPlayerAi.UnitTests.Datastructures
{
    public class EmptyPriorityQueueWithDefaultComparer
    {
        private readonly PriorityQueue<int> _priorityQueue;

        public EmptyPriorityQueueWithDefaultComparer()
        {
            _priorityQueue = new PriorityQueue<int>();
        }

        [Fact]
        public void ShouldPopElementsInAscendingOrder()
        {
            _priorityQueue.Push(3);
            _priorityQueue.Push(1);
            _priorityQueue.Push(2);

            Assert.Equal(1, _priorityQueue.Pop());
            Assert.Equal(2, _priorityQueue.Pop());
            Assert.Equal(3, _priorityQueue.Pop());
        }

        [Fact]
        public void ShouldPeekElementWithLowestPriority()
        {
            _priorityQueue.Push(3);
            _priorityQueue.Push(1);
            _priorityQueue.Push(2);

            Assert.Equal(1, _priorityQueue.Peek());
            Assert.Equal(1, _priorityQueue.Peek());
            Assert.Equal(1, _priorityQueue.Pop());
            Assert.Equal(2, _priorityQueue.Peek());
        }

        [Fact]
        public void ShouldReturnTheCountOfElements()
        {
            _priorityQueue.Push(3);
            _priorityQueue.Push(1);
            _priorityQueue.Push(2);

            Assert.Equal(3, _priorityQueue.Count);
        }

        [Fact]
        public void ShouldReturnIsEmpty()
        {
            _priorityQueue.Push(1);
            Assert.Equal(false, _priorityQueue.IsEmpty);

            _priorityQueue.Pop();
            Assert.Equal(true, _priorityQueue.IsEmpty);
        }
    }

    public class EmptyPriorityQueueWithCustomComparer
    {
        private readonly PriorityQueue<int> _priorityQueue;

        public EmptyPriorityQueueWithCustomComparer()
        {
            IComparer<int> comparer = new ReverseComparer();
            _priorityQueue = new PriorityQueue<int>(comparer);
        }

        private class ReverseComparer : IComparer<int>
        {
            public int Compare(int a, int b)
            {
                return -(a-b);
            }
        }

        [Fact]
        public void ShouldPopElementsInAscendingOrderDefinedByComparer()
        {
            _priorityQueue.Push(3);
            _priorityQueue.Push(1);
            _priorityQueue.Push(2);

            Assert.Equal(3, _priorityQueue.Pop());
            Assert.Equal(2, _priorityQueue.Pop());
            Assert.Equal(1, _priorityQueue.Pop());
        }

        [Fact]
        public void ShouldPeekElementWithLowestPriorityDefinedByComparer()
        {
            _priorityQueue.Push(3);
            _priorityQueue.Push(1);
            _priorityQueue.Push(2);

            Assert.Equal(3, _priorityQueue.Peek());
            Assert.Equal(3, _priorityQueue.Peek());
            Assert.Equal(3, _priorityQueue.Pop());
            Assert.Equal(2, _priorityQueue.Peek());
        }

        [Fact]
        public void ShouldReturnTheCountOfElements()
        {
            _priorityQueue.Push(3);
            _priorityQueue.Push(1);
            _priorityQueue.Push(2);

            Assert.Equal(3, _priorityQueue.Count);
        }

        [Fact]
        public void ShouldReturnIsEmpty()
        {
            _priorityQueue.Push(1);
            Assert.Equal(false, _priorityQueue.IsEmpty);

            _priorityQueue.Pop();
            Assert.Equal(true, _priorityQueue.IsEmpty);
        }
    }

    public class NonEmptyPriorityQueueWithDefaultComparer
    {
        private readonly PriorityQueue<int> _priorityQueue;

        public NonEmptyPriorityQueueWithDefaultComparer()
        {   
            int[] elements = {3, 1, 2};
            _priorityQueue = new PriorityQueue<int>(elements);
        }

        [Fact]
        public void ShouldPopElementsInAscendingOrder()
        {
            Assert.Equal(1, _priorityQueue.Pop());
            Assert.Equal(2, _priorityQueue.Pop());
            Assert.Equal(3, _priorityQueue.Pop());
        }

        [Fact]
        public void ShouldPeekElementWithLowestPriority()
        {
            Assert.Equal(1, _priorityQueue.Peek());
            Assert.Equal(1, _priorityQueue.Peek());
            Assert.Equal(1, _priorityQueue.Pop());
            Assert.Equal(2, _priorityQueue.Peek());
        }

        [Fact]
        public void ShouldReturnTheCountOfElements()
        {
            Assert.Equal(3, _priorityQueue.Count);
        }

        [Fact]
        public void ShouldReturnIsEmpty()
        {
            Assert.Equal(false, _priorityQueue.IsEmpty);

            _priorityQueue.Pop();
            _priorityQueue.Pop();
            _priorityQueue.Pop();
            Assert.Equal(true, _priorityQueue.IsEmpty);
        }
    }
}