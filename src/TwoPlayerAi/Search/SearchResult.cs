using System.Collections.Generic;

namespace TwoPlayerAi.Search
{
    public class SearchResult<T>
    {
        private Node<T> _node;
        public SearchResult(Node<T> node)
        {
            _node = node;
        }

        public bool IsSuccess
        {
            get
            {
                return (_node != null);
            }
        }

        public IEnumerable<T> States
        {
            get
            {
                Node<T> currentNode = _node; 
                while(currentNode != null)
                {
                    yield return currentNode.State;
                    currentNode = currentNode.Parent;
                }
            }
        }

        public IEnumerable<IAction<T>> Actions
        {
            get
            {
                Node<T> currentNode = _node; 
                while(currentNode != null)
                {
                    yield return currentNode.Action;
                    currentNode = currentNode.Parent;
                }
            }
        }

        public int Cost
        {
            get
            {
                return _node.PathCost;
            }
        }
    }
}