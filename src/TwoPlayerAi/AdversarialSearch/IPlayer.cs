using System;

namespace TwoPlayerAi.AdversarialSearch
{
     public interface IPlayer: IEquatable<IPlayer>
     {
         String Identifier { get;  }

         bool IsMax { get; }

         bool IsMin { get; }
     }
}