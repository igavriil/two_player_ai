using System;
using Xunit;
using System.Collections.Generic;
using TwoPlayerAi.AdjacencyMatrices;

namespace TwoPlayerAi.Tests.AdjacencyMatrices
{
    public class Edge
    {
        [Fact]
        public void ShouldSetSourceAndDestination()
        {
            Edge<String> edge = new Edge<String>("a", "b", 1);
            Assert.Equal("a", edge.Source);
            Assert.Equal("b", edge.Destination);
        }

        [Fact]
        public void ShouldSetWeight()
        {
            Edge<String> edge = new Edge<String>("a", "b", 1);
            Assert.Equal(1, edge.Weight);
        }

        [Fact]
        public void ShouldBeweighted()
        {
            Edge<String> edge = new Edge<String>("a", "b", 1);
            Assert.Equal(true, edge.IsWeighted);
        }

        [Fact]
        public void ShouldBeEquitable()
        {
            Edge<String> edge = new Edge<String>("a", "b", 1);
            Edge<String> equal = new  Edge<String>("a","b",1);
            Edge<String> unequalVetices = new  Edge<String>("b","a",1);
            Edge<String> unequalWeights = new  Edge<String>("a","b",2);

            Assert.Equal(true, edge.Equals(equal));
            Assert.Equal(false, edge.Equals(unequalVetices));
            Assert.Equal(false, edge.Equals(unequalWeights));
        }

        [Fact]
        public void ShouldOverrideToString()
        {
            Edge<String> edge = new Edge<String>("a", "b", 1);
            Assert.Equal("a->b:1", edge.ToString());
        }
    }
}