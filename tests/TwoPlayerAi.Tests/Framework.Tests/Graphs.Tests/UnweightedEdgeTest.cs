using System;
using Xunit;
using System.Collections.Generic;
using TwoPlayerAi.Framework.Graphs;

namespace TwoPlayerAi.UnitTests.Framework.Graphs
{
    public class UnweightedEgde
    {
        private readonly UnweightedEdge<String> _unweightedEgde;

        public UnweightedEgde()
        {
            _unweightedEgde = new UnweightedEdge<String>("a", "b");
        }

        [Fact]
        public void ShouldSetSourceAndDestination()
        {
            Assert.Equal("a", _unweightedEgde.Source);
            Assert.Equal("b", _unweightedEgde.Destination);
        }

        [Fact]
        public void ShouldBeUnweighted()
        {
            Assert.Equal(false, _unweightedEgde.IsWeighted);
        }

        [Fact]
        public void ShouldBeEquitable()
        {
            IEdge<String> equal = new  UnweightedEdge<String>("a", "b");
            IEdge<String> unequal = new  UnweightedEdge<String>("b", "a");

            Assert.Equal(true, _unweightedEgde.Equals(equal));
            Assert.Equal(false, _unweightedEgde.Equals(unequal));
        }
    }
}