using System;
using Xunit;
using System.Collections.Generic;
using TwoPlayerAi.Framework.Graphs;

namespace TwoPlayerAi.UnitTests.Framework.Graphs
{
    public class WeightedEgde
    {
        private readonly WeightedEdge<String> _weightedEgde;

        public WeightedEgde()
        {
            _weightedEgde = new WeightedEdge<String>("a", "b", 1);
        }

        [Fact]
        public void ShouldSetSourceAndDestination()
        {
            Assert.Equal("a", _weightedEgde.Source);
            Assert.Equal("b", _weightedEgde.Destination);
        }

        [Fact]
        public void ShouldSetWeight()
        {
            Assert.Equal(1, _weightedEgde.Weight);
        }

        [Fact]
        public void ShouldBeweighted()
        {
            Assert.Equal(true, _weightedEgde.IsWeighted);
        }

        [Fact]
        public void ShouldBeEquitable()
        {
            IEdge<String> equal = new  WeightedEdge<String>("a","b",1);
            IEdge<String> unequalVetices = new  WeightedEdge<String>("b","a",1);
            IEdge<String> unequalWeights = new  WeightedEdge<String>("a","b",2);

            Assert.Equal(true, _weightedEgde.Equals(equal));
            Assert.Equal(false, _weightedEgde.Equals(unequalVetices));
            Assert.Equal(false, _weightedEgde.Equals(unequalWeights));
        }
    }
}