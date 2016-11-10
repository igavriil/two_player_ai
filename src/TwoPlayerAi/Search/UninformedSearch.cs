namespace TwoPlayerAi.Search
{
    public abstract class UninformedSearch
    {
        private IProblem _problem { get; }
        private IFrontier<IState> _frontier { get; }
        public UninformedSearch(IProblem problem, IFrontier<IState> frontier)
        {
            _problem = problem;
            _frontier = frontier;
        }

        public Node Run()
        {
            
        }
    }
}