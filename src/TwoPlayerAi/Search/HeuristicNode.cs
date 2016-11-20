using System;

namespace TwoPlayerAi.Search
{
    public class HeuristicNode<T> : Node<T>, IComparable<HeuristicNode<T>>
        where T : IEquatable<T>
    {
        public int HeuristicCost { get; }

        public HeuristicNode(T state, IAction<T> action, Node<T> parent, int pathCost, int heuristicCost) :
            base(state, action, parent, pathCost)
        {
            HeuristicCost = heuristicCost;
        }

        public HeuristicNode(T state, int heuristicCost) :
            base(state)
        {
            HeuristicCost = heuristicCost;
        }

        public HeuristicNode<T> ChildNode(IProblem<T> problem, IAction<T> action, IHeustisticFunction<T> heurisctic)
        {
            T state = problem.Transition(this.State, action);
            int stepCost = problem.StepCost(this.State, action);
            int totalCost = this.PathCost + stepCost;
            int heuristicCost = totalCost + heurisctic.Calculate(problem, state);
            return new HeuristicNode<T>(state, action, this, totalCost, heuristicCost); 
        }

        public int CompareTo(object other) {
            if (other == null)
            {
                return 1;
            }

            HeuristicNode<T> otherHeuristicNode = other as HeuristicNode<T>;
            return this.CompareTo(otherHeuristicNode);
        }

        public int CompareTo(HeuristicNode<T> other) {
            return this.HeuristicCost.CompareTo(other.HeuristicCost);
        }
    }
}