namespace TwoPlayerAi.Search
{
    public interface IHeuristicProblem<T>
    {
        int Heuristic(T state);
    }
}