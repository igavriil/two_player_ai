using System;

namespace TwoPlayerAi.AdjacencyMatrices
{
    public class Edge<TVertex> : IEquatable<Edge<TVertex>>
        where TVertex : IEquatable<TVertex>
    {

        public Edge(TVertex source, TVertex destination, int weight)
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

        public bool Equals(Edge<TVertex> other)
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

        public override bool Equals(object other)
        {
            Edge<TVertex> Edge = other as Edge<TVertex>;
            return this.Equals(Edge);
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
            return $"{Source}->{Destination}:{Weight}";
        }
    }
}