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
            Console.WriteLine(board);
            
        }

        [Fact]
        public void ShouldDoSomething()
        {
        }
    }
}