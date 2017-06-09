using System;
using TwoPlayerAi.Search;

namespace TwoPlayerAi.AdversarialSearch
{
    public class AlphaBeta<T> where T : IEquatable<T>
    {
        private IGame<T> _game;

        public AlphaBeta(IGame<T> game)
        {
            _game = game;
        }

        public int Calculate(T state, int depth, int alpha, int beta, bool maxPlayer)
        {

            if (depth == 0)
            {
                return _game.HeuristicFunction(state, player);
            }

            if (_game.TerminalTest(state)))
             {
                return _game.UtilityFunction(state, player);
            }

            if (maxPlayer)
            {
                int max = int.MinValue;
                foreach (IAction<T> action in game.Actions(state))
                {
                    T childState = game.Result(state, action);
                    int heuristicValue = Math.max(heuristicValue, Calculate(childState, depth - 1, alpha, beta, false);
                    alpha = Math.Max(alpha, heuristicValue)
                    if (beta <= alpha)
                    {
                        break
                    }
                }
                return heuristicValue;
            }
            else
            {
                int min = int.MaxValue;
                foreach (IAction<T> action in game.Actions(state))
                {
                    T childState = game.Result(state, action);
                    int heuristicValue = Math.min(heuristicValue, Calculate(childState, depth - 1, alpha, beta, true);
                    beta = Math.Min(beta, heuristicValue)
                    if (beta <= alpha)
                    {
                        break
                    }
                }
                return heuristicValue;
            }
        }
    }
}