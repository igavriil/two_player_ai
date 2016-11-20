using System;
using Xunit;
using TwoPlayerAi.Games;

namespace TwoPlayerAi.Tests.Games
{
    public class VectorTest
    {
        [Fact]
        public void ShouldSetXAndYn()
        {
            Vector vector = new Vector(1, 2);
            Assert.Equal(1, vector.X);
            Assert.Equal(2, vector.Y);
        }

        [Fact]
        public void ShouldDefineAddition()
        {
            Vector vectorA = new Vector(1, 2);
            Vector vectorB = new Vector(2, 3);
            Assert.Equal(new Vector(3, 5), vectorA + vectorB);
        }

        [Fact]
        public void ShouldDefineSubstraction()
        {
            Vector vectorA = new Vector(1, 2);
            Vector vectorB = new Vector(2, 3);
            Assert.Equal(new Vector(-1, -1), vectorA - vectorB);
        }

        [Fact]
        public void ShouldDefineMultiplication()
        {
            Vector vector = new Vector(1, 2);
            Assert.Equal(new Vector(2, 4), 2 * vector);
        }

        [Fact]
        public void ShouldBeEquitable()
        {
            Vector vector = new Vector(1, 2);
            Vector equal = new  Vector(1, 2);
            Vector unequalX = new  Vector(2, 2);
            Vector unequalY = new  Vector(1, 1);

            Assert.Equal(true, vector.Equals(equal));
            Assert.Equal(false, vector.Equals(unequalX));
            Assert.Equal(false, vector.Equals(unequalY));
        }

        [Fact]
        public void ShouldOverrideToString()
        {
            Vector vector = new Vector(1, 2);
            Assert.Equal("x:1,y:2", vector.ToString());
        }
    }
}