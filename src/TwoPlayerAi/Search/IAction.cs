namespace TwoPlayerAi.Search
{
    public interface IAction<T>
    {
        T FromState { get; }

        T ToState { get; }

        int Cost { get; }
    }
}