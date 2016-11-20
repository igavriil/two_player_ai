using System;

namespace TwoPlayerAi.Search
{
    public class Node<T> 
        where T : IEquatable<T>
    {
        public T State { get; }
        public Node<T> Parent { get; }
        public IAction<T> Action { get; }
        public int PathCost { get; }

        public Node(T state, IAction<T> action, Node<T> parent, int pathCost)
        {
            State = state;
            Action = action;
            Parent = parent;
            PathCost = pathCost;
        }

        public Node(T state): this(state, null, null, 0) {}

        public Node<T> ChildNode(IProblem<T> problem, IAction<T> action)
        {
            T state = problem.Transition(this.State, action);
            int stepCost = problem.StepCost(this.State, action);
            int totalCost = this.PathCost + stepCost;
            return new Node<T>(state, action, this, totalCost); 
        }
    }
}