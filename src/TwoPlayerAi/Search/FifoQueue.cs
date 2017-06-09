using System.Collections.Generic;

namespace TwoPlayerAi.Search
{
    public class FifoQueue<T> : Queue<T>, IFrontier<T>
    {
        private Stack<T> _stack;

        public FifoQueue()
        {
            _stack = new Stack<T>();
        }
        public bool IsEmpty
        {
            get
            {
                return _stack.Count == 0;
            }
        }
        public T First
        {
            get
            {
                return _stack.Peek();
            }
        }
        public T Take()
        {
            return _stack.Pop();
        }
        public void Put(T element)
        {
            _stack.Push(element);
        }
        public void Put(IEnumerable<T> elements)
        {
            foreach (T element in elements)
            {
                this.Put(element);
            }
        }
    }
}