using System;

namespace TwoPlayerAi.Graphs
{
    public interface IEdge<TVertex> : IEquatable<IEdge<TVertex>> where TVertex : IEquatable<TVertex>
    {
        TVertex Source { get; }

        TVertex Destination { get; }

        bool IsWeighted { get; }
    }
}