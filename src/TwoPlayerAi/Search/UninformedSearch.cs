using System.Collections.Generic;
namespace TwoPlayerAi.Search
{
    public class UninformedSearch<T>
    {
        public IProblem<T> Problem { get; }
        public IFrontier<Node<T>> Frontier { get; }
        public HashSet<T> OpenList { get; }
        public HashSet<T> ClosedList { get; }
        public UninformedSearch(IProblem<T> problem, IFrontier<Node<T>> frontier)
        {
            Problem = problem;
            Frontier = frontier;
            OpenList = new HashSet<T>();
            ClosedList = new HashSet<T>();
        }

        public SearchResult<T> Search()
        {
            T state = Problem.InitialState();
            Node<T> node = new Node<T>(state);
            if (Problem.GoalTest(state))
            {
                return new SearchResult<T>(node);
            }
            Frontier.Put(node);
            OpenList.Add(state);

            while (!Frontier.IsEmpty)
            {
                node = Frontier.Take();
                state = node.State;
                ClosedList.Add(state);
                foreach (IAction<T> action in Problem.Actions(state))
                {
                    Node<T> childNode = node.ChildNode(Problem, action);
                    T childState = childNode.State;
                    if (!ClosedList.Contains(childState) && !OpenList.Contains(childState))
                    {
                        if (Problem.GoalTest(childState))
                        {
                            return new SearchResult<T>(childNode);
                        }
                        Frontier.Put(childNode);
                        OpenList.Add(childState);
                    }
                }
            }
            return new SearchResult<T>(null);
        }
    }
}