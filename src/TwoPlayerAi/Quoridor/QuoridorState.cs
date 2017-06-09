using System.Collections.Generic;
using TwoPlayerAi.Games;

namespace TwoPlayerAi.Quoridor
{
    public class QuoridorState
    {
        public Board Board;

        IEnumerable<QuoridorPlayer> Players { get; set; }

    }
}