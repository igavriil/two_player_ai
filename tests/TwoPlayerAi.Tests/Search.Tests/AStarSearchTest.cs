using System;
using System.Collections;
using System.Collections.Generic;
using TwoPlayerAi.AdjacencyMatrices;
using TwoPlayerAi.Graphs;
using TwoPlayerAi.Search;
using TwoPlayerAi.GraphProblems;
using TwoPlayerAi.DataStructures;
using TwoPlayerAi.Games;
using System.Linq;
using Xunit;

namespace TwoPlayerAi.Tests.Search
{
    public class AStarSearch
    {
        private readonly GraphProblem<Vector> _problem;

        public AStarSearch()
        {
            Board board = new Board(5);
            Vector startState = new Vector(0,4);
            Vector goalState = new Vector(4,0);
            _problem = new GraphProblem<Vector>(board, startState, goalState);

        }

        [Fact]
        public void AStarWithManhattanDistance()
        {
            ManhattanDistanceHeuristic<Vector> heuristic = new ManhattanDistanceHeuristic<Vector>();
            AStarSearch<Vector> aStarSearch = new AStarSearch<Vector>(_problem, heuristic);
            SearchResult<Vector> searchResult = aStarSearch.Search();
            List<Vector> states = searchResult.States.ToList();

            Console.WriteLine("AStar with manhattan");
            Console.WriteLine($"OpenList:{aStarSearch.OpenList.Count}");
            Console.WriteLine($"ClosedList:{aStarSearch.ClosedList.Count}");
            foreach (var state in states)
            {
                Console.WriteLine(state);
            }
        }

        [Fact]
        public void AStarWithSquareDistance()
        {
            SquareDistanceHeuristic<Vector> heuristic = new SquareDistanceHeuristic<Vector>();
            AStarSearch<Vector> aStarSearch = new AStarSearch<Vector>(_problem, heuristic);
            SearchResult<Vector> searchResult = aStarSearch.Search();
            List<Vector> states = searchResult.States.ToList();

            Console.WriteLine("AStar with square");
            Console.WriteLine($"OpenList:{aStarSearch.OpenList.Count}");
            Console.WriteLine($"ClosedList:{aStarSearch.ClosedList.Count}");
            foreach (var state in states)
            {
                Console.WriteLine(state);
            }
        }

        [Fact]
        public void AStarWithDistance()
        {
            DistanceHeuristic<Vector> heuristic = new DistanceHeuristic<Vector>();
            AStarSearch<Vector> aStarSearch = new AStarSearch<Vector>(_problem, heuristic);
            SearchResult<Vector> searchResult = aStarSearch.Search();
            List<Vector> states = searchResult.States.ToList();

            Console.WriteLine("AStar with distance");
            Console.WriteLine($"OpenList:{aStarSearch.OpenList.Count}");
            Console.WriteLine($"ClosedList:{aStarSearch.ClosedList.Count}");
            foreach (var state in states)
            {
                Console.WriteLine(state);
            }
        }

        [Fact]
        public void AStarWithDiagonalDistance()
        {
            DiagonalDistanceHeuristic<Vector> heuristic = new DiagonalDistanceHeuristic<Vector>();
            AStarSearch<Vector> aStarSearch = new AStarSearch<Vector>(_problem, heuristic);
            SearchResult<Vector> searchResult = aStarSearch.Search();
            List<Vector> states = searchResult.States.ToList();

            Console.WriteLine("AStar with diagonal");
            Console.WriteLine($"OpenList:{aStarSearch.OpenList.Count}");
            Console.WriteLine($"ClosedList:{aStarSearch.ClosedList.Count}");
            foreach (var state in states)
            {
                Console.WriteLine(state);
            }
        }
    }
}