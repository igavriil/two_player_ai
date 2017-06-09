using TwoPlayerAi.Search;

namespace TwoPlayerAi.Quoridor
{
    public class QuoridorAction : IAction<QuoridorState>
    {
        public QuoridorState FromState { get; }

        public QuoridorState ToState { get; }

        public int Cost { get; }

        public QuoridorAction(QuoridorState fromState, QuoridorState toState)
        {
            FromState = from;
            ToState = to;
            Cost = 1;
        }
    }

    public class FenceAction : QuoridorAction
    {

    }

    public class PlayerAction : QuoridorAction
    {

    }
}