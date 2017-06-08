using System;
using System.Collections.Generic;
using TwoPlayerAi.Games;

namespace TwoPlayerAi.Quoridor
{
    public class State
    {
        public Board Board;
        IEnumerable<Player> Players { get; set; }
     
    }
}