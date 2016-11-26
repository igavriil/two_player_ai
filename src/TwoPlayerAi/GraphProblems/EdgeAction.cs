using System;
using TwoPlayerAi.Search;
using TwoPlayerAi.AdjacencyMatrices;

namespace TwoPlayerAi.GraphProblems
{
    public class EdgeAction<T> : IAction<T>
            where T : IEquatable<T>
    {
        private Edge<T> _edge;

        public EdgeAction(Edge<T> edge)
        {
            _edge = edge;
        }

        public T FromState
        {
            get
            {
                return _edge.Source;
            }
        }

        public T ToState
        {
            get
            {
                return _edge.Destination;
            }
        }

        public int Cost
        {
            get
            {
                return _edge.Weight;
            }
        }

        public bool Equals(EdgeAction<T> other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                bool states_equal = FromState.Equals(other.FromState) && ToState.Equals(other.ToState);
                bool costs_equal = Cost.Equals(other.Cost);
                return states_equal && costs_equal;
            }
        }

        public override bool Equals(object other)
        {
            EdgeAction<T> EdgeVertex = other as EdgeAction<T>;
            return this.Equals(EdgeVertex);
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + FromState.GetHashCode();
            hash = (hash * 7) + ToState.GetHashCode();
            return hash + Cost;
        }

        public override string ToString()
        {
            return _edge.ToString();
        }
    }
}