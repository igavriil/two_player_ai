using System;

namespace TwoPlayerAi.Framework.Graphs
{
    public class UnweightedEdge<TVertex> : IEdge<TVertex> where TVertex : IEquatable<TVertex>
    {

        public UnweightedEdge(TVertex source, TVertex destination)
        {
            Source = source;
            Destination = destination;
        }

        public TVertex Source { get; }

        public TVertex Destination { get; }

        public bool IsWeighted
        {
            get
            {
                return false;
            }
        }

        public bool Equals(UnweightedEdge<TVertex> other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                bool verices_equal = Source.Equals(other.Source) && Destination.Equals(other.Destination);
                return verices_equal;
            }
        }

        public bool Equals(IEdge<TVertex> other)
        {
            if (other.IsWeighted)
            {
                return false;
            }
            else
            {
                UnweightedEdge<TVertex> unweightedEdge = other as UnweightedEdge<TVertex>;
                return this.Equals(unweightedEdge);
            }
        }

        public override bool Equals(object other)
        {
            UnweightedEdge<TVertex> UnweightedEdge = other as UnweightedEdge<TVertex>;
            return this.Equals(UnweightedEdge);
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Source.GetHashCode();
            hash = (hash * 7) + Destination.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return "UnweightedEdge: " + this.Source.ToString() + "->" + this.Destination.ToString();
        }
    }
}