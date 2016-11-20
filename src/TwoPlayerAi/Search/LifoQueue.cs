using System.Collections.Generic;

namespace TwoPlayerAi.Search
{
    public class LifoQueue<T>: Queue<T>, IFrontier<T>
    {
        private Queue<T> _queue;

        public LifoQueue()
        {
            _queue = new Queue<T>();
        }
        public bool IsEmpty 
        { 
            get 
            {
               return  _queue.Count == 0;
            } 
        }
        public T First 
        { 
            get 
            {
                return _queue.Peek();
            } 
        }
        public T Take()
        {
            return _queue.Dequeue();
        }
        public void Put(T element)
        {
            _queue.Enqueue(element);
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