using System;

namespace TwoPlayerAi.Framework.Graphs
{
    public class WeightedEdge<TVertex> : IEdge<TVertex>, IEquatable<WeightedEdge<TVertex>>
        where TVertex : IEquatable<TVertex>
    {

        public WeightedEdge(TVertex source, TVertex destination, int weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }

        public TVertex Source { get; }

        public TVertex Destination { get; }

        public int Weight { get; }

        public bool IsWeighted
        {
            get
            {
                return true;
            }
        }

        public bool Equals(WeightedEdge<TVertex> other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                bool vertices_equal = Source.Equals(other.Source) && Destination.Equals(other.Destination);
                bool weights_equal = Weight.Equals(other.Weight);
                return vertices_equal && weights_equal;
            }
        }

        public bool Equals(IEdge<TVertex> other)
        {
            if (!other.IsWeighted)
            {
                return false;
            }
            else
            {
                WeightedEdge<TVertex> weightedEdge = other as WeightedEdge<TVertex>;
                return this.Equals(weightedEdge);
            }
        }

        public override bool Equals(object other)
        {
            WeightedEdge<TVertex> weightedEdge = other as WeightedEdge<TVertex>;
            return this.Equals(weightedEdge);
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Source.GetHashCode();
            hash = (hash * 7) + Destination.GetHashCode();
            return hash + Weight;
        }

        public override string ToString()
        {
            return "WeightedEdge: " + this.Source.ToString() + "->" + this.Destination.ToString() + ":" + this.Weight.ToString();
        }
    }
}