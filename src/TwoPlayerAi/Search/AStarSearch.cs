using System;
using TwoPlayerAi.DataStructures;
using System.Collections.Generic;

namespace TwoPlayerAi.Search
{
    public class AStarSearch<T>
        where T : IEquatable<T>
    {
        public IInformedProblem<T> Problem { get; }
        public PriorityQueue<HeuristicNode<T>> PriorityQueue { get; }
        public HashSet<T> OpenList { get; }
        public HashSet<T> ClosedList { get; }

        public IHeustisticFunction<T> Heuristic { get; }
        public AStarSearch(IInformedProblem<T> problem, IHeustisticFunction<T> heuristic)
        {
            Problem = problem;
            Heuristic = heuristic;
            PriorityQueue = new PriorityQueue<HeuristicNode<T>>();
            OpenList = new HashSet<T>();
            ClosedList = new HashSet<T>();
        }

        public SearchResult<T> Search()
        {
            T state = Problem.InitialState;
            HeuristicNode<T> node = new HeuristicNode<T>(state, 1);
            if (Problem.GoalTest(state))
            {
                return new SearchResult<T>(node);
            }
            PriorityQueue.Push(node);
            OpenList.Add(state);

            while (!PriorityQueue.IsEmpty)
            {
                node = PriorityQueue.Pop();
                state = node.State;
                ClosedList.Add(state);
                foreach (IAction<T> action in Problem.Actions(state))
                {
                    HeuristicNode<T> childNode = node.ChildNode(Problem, action, Heuristic);
                    T childState = childNode.State;
                    if (ClosedList.Contains(childState) || OpenList.Contains(childState))
                    {
                        if (PriorityQueue.Contains(childNode) && childNode.HeuristicCost > node.HeuristicCost)
                        {
                            PriorityQueue.Push(childNode);
                            OpenList.Add(childState);
                        }
                    }

                    if (!ClosedList.Contains(childState) && !OpenList.Contains(childState))
                    {

                        if (Problem.GoalTest(childState))
                        {
                            return new SearchResult<T>(childNode);
                        }
                        PriorityQueue.Push(childNode);
                        OpenList.Add(childState);
                    }
                }
            }
            return new SearchResult<T>(null);
        }
    }
}