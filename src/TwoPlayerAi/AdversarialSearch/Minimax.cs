using System;
using TwoPlayerAi.Search;

namespace TwoPlayerAi.AdversarialSearch
{
     public class Minimax<T>
        where T: IEquatable<T>
     {
         public int Search(IGame<T> game, T state, int depth)
         {
             IPlayer player = game.Player(state);
             if(depth == 0 || game.TerminalTest(state))
             {
                 return game.UtilityFunction(state, player);
             }

             if(player.IsMax)
             {
                 int max = int.MinValue;
                 foreach (IAction<T> action in game.Actions(state))
                 {
                    T childState = game.Result(state, action);
                    int utilityValue = game.UtilityFunction(childState, player);
                    max = Math.Max(max, utilityValue);
                 }
                 return max;
             } else {
                 int min = int.MaxValue;
                 foreach (IAction<T> action in game.Actions(state))
                 {
                    T childState = game.Result(state, action);
                    int utilityValue = game.UtilityFunction(childState, player);
                    min = Math.Min(min, utilityValue);
                 }
                 return min;
             }
         }
     }
}