using System;
using System.Collections.Generic;
using TwoPlayerAi.AdversarialSearch;
using TwoPlayerAi.DataStructures;

namespace TwoPlayerAi.Quoridor
{
    public class Player: IPlayer
     {
         private String _identifier;

         private bool _isMax;

         private bool _isMin; 

         public Vector Position { get; set; }

         public IEnumerable<Vector> GoalPositions { get; set; }

         public int WallsCount { get; set; }
         public Player(String identifier, bool isMax, bool isMin)
         {
            _identifier = identifier;
            _isMax = isMax;
            _isMin = isMin;
         }

         public String Identifier 
         { 
             get 
             {
                return _identifier;
             }  
         }

         public bool IsMax 
         { 
             get
             {
                 return _isMax;
             } 
         }

         public bool IsMin 
         { 
             get
             {
                 return _isMin;
             } 
         
         }
     }

     public class MaxPlayer : Player
     {
         public MaxPlayer(String identifier) : base(identifier, true, false) { }
     }

     public class MinPlayer : Player
     {
         public MinPlayer(String identifier) : base(identifier, false, true) { }
     }
}