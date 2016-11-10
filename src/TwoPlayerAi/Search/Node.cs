namespace TwoPlayerAi.Search
{
    public class Node
    {
        public IState State { get; }

        public Node Parent { get; }
        public IAction Action { get; }

        public int PathCost { get; }

        public Node(IState state, IAction action, Node parent, int pathCost)
        {
            State = state;
            Action = action;
            Parent = parent;
            PathCost = pathCost;
        }

        public Node(IState state): this(state, null, null, 0) {}

        public Node ChildNode(IProblem problem, IAction action)
        {
            IState state = problem.Transition(this.State, action);
            int stepCost = problem.StepCost(this.State, action);
            int totalCost = this.PathCost + stepCost;
            return new Node(state, action, this,totalCost); 
        }
    }
}