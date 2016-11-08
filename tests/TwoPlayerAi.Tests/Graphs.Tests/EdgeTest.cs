using System;
using Xunit;
using System.Collections.Generic;
using TwoPlayerAi.Graphs.AdjacencyMatrices;

namespace TwoPlayerAi.Tests.Graphs
{
    public class Edge
    {
        private readonly Edge<String> _edge;

        public Edge()
        {
            _edge = new Edge<String>("a", "b", 1);
        }

        [Fact]
        public void ShouldSetSourceAndDestination()
        {
            Assert.Equal("a", _edge.Source);
            Assert.Equal("b", _edge.Destination);
        }

        [Fact]
        public void ShouldSetWeight()
        {
            Assert.Equal(1, _edge.Weight);
        }

        [Fact]
        public void ShouldBeweighted()
        {
            Assert.Equal(true, _edge.IsWeighted);
        }

        [Fact]
        public void ShouldBeEquitable()
        {
            Edge<String> equal = new  Edge<String>("a","b",1);
            Edge<String> unequalVetices = new  Edge<String>("b","a",1);
            Edge<String> unequalWeights = new  Edge<String>("a","b",2);

            Assert.Equal(true, _edge.Equals(equal));
            Assert.Equal(false, _edge.Equals(unequalVetices));
            Assert.Equal(false, _edge.Equals(unequalWeights));
        }
    }
}