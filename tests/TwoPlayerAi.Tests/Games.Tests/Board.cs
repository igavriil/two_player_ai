using System;
using Xunit;
using TwoPlayerAi.Games;

namespace TwoPlayerAi.Tests.Games
{
    public class BoardTest
    {
        public BoardTest()
        {
            Board board = new Board(5);
            board.RemoveEdge(new Vector(1,2), new Vector(2,2));
            Console.WriteLine(board);
            
        }

        [Fact]
        public void ShouldDefineSubstraction()
        {
            Vector vectorA = new Vector(1, 2);
            Vector vectorB = new Vector(2, 3);
            Assert.Equal(new Vector(-1, -1), vectorA - vectorB);
        }
    }
}