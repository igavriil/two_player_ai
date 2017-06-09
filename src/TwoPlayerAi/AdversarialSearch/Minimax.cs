using System;
using TwoPlayerAi.Search;

namespace TwoPlayerAi.AdversarialSearch
{
    public class Minimax<T> where T : IEquatable<T>
    {
        private IGame<T> _game;

        public Minimax(IGame<T> game)
        {
            _game = game;
        }

        public int Calculate(T state, int depth, bool maxPlayer)
        {

            if (depth == 0 || _game.TerminalTest(state))
            {
                return _game.UtilityFunction(state, player);
            }

            if (maxPlayer)
            {
                int max = int.MinValue;
                foreach (IAction<T> action in game.Actions(state))
                {
                    T childState = game.Result(state, action);
                    int utilityValue = Calculate(childState, depth - 1, false);
                    max = Math.Max(max, utilityValue);
                }
                return max;
            }
            else
            {
                int min = int.MaxValue;
                foreach (IAction<T> action in game.Actions(state))
                {
                    T childState = game.Result(state, action);
                    int utilityValue = Calculate(childState, depth - 1, true);
                    min = Math.Min(min, utilityValue);
                }
                return min;
            }
        }
    }
}