namespace TwoPlayerAi.Search
{
    public interface IHeuristicProblem
    {
        int Heuristic(IState state);
    }
}