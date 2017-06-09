using TwoPlayerAi.AdversarialSearch;

namespace TwoPlayerAi.Quoridor
{
    public class Quoridor : IGame<QuoridorState>
    {
        public QuoridorState InitialState
        {

        }

        public QuoridorPlayer Player(QuoridorState state)
        {

        }

        public QuoridorState Result(QuoridorState state, QuoridorAction<QuoridorState> action)
        {

        }

        public bool TerminalTest(QuoridorState state)
        {
            return true;
        }

        public int UtilityFunction(QuoridorState state, QuoridorPlayer player)
        {
            return 1;
        }

        public int HeuristicFunction(QuoridorState state, QuoridorPlayer player)
        {
            return 1;
        }
    }
}