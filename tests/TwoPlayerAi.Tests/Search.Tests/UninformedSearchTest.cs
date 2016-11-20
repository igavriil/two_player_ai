using System;
using System.Collections;
using System.Collections.Generic;
using TwoPlayerAi.AdjacencyMatrices;
using TwoPlayerAi.Graphs;
using TwoPlayerAi.Search;
using System.Linq;
using Xunit;

namespace TwoPlayerAi.Tests.Search
{
    public class UninformedSearch
    {
        private class EdgeAction<T> : IAction<T>
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
                return "EdgeAction: " + this.FromState.ToString() + "->" + this.ToState.ToString() + ":" + this.Cost.ToString();
            }
        }

        private class GraphProblem<T> : IProblem<T>
            where T : IEquatable<T>
        {
            private T _initialState;
            private T _goalState;
            private IGraph<T> _graph;

            public GraphProblem(IGraph<T> graph, T initialState, T goalState)
            {
                _graph = graph;
                _initialState = initialState;
                _goalState = goalState;
            }

            public T InitialState()
            {
                return _initialState;
            }

            public IEnumerable<IAction<T>> Actions(T state)
            {
                foreach (Edge<T> edge in  _graph.OutgoingEdges(state))
                {   
                    yield return new EdgeAction<T>(edge); 
                }
            }

            public T Transition(T state, IAction<T> action)
            {
                return action.ToState;
            }

            public bool GoalTest(T state)
            {
                return _goalState.Equals(state);
            }

            public int StepCost(T state, IAction<T> action)
            {
                return action.Cost;
            }
        }

        private readonly GraphProblem<string> _problem;


        public UninformedSearch()
        {
            UndirectedSparseGraph<String> graph = new UndirectedSparseGraph<String>();
            string[] vertices = new string[] { "a", "b", "c", "d", "e", "f", "g"};

            graph.AddVertices(vertices);

            graph.SetEdge("a", "c", 1);
            graph.SetEdge("a", "d", 1);
            graph.SetEdge("b", "c", 1);
            graph.SetEdge("b", "e", 1);
            graph.SetEdge("d", "g", 1);
            graph.SetEdge("e", "f", 1);
            graph.SetEdge("f", "g", 1);

            _problem = new GraphProblem<string>(graph, "a", "e");

            List<EdgeAction<String>> actionsFromA = _problem.Actions("a").Cast<EdgeAction<String>>().ToList();
            List<EdgeAction<String>> actionsFromB = _problem.Actions("b").Cast<EdgeAction<String>>().ToList();
            List<EdgeAction<String>> actionsFromC = _problem.Actions("c").Cast<EdgeAction<String>>().ToList();
            List<EdgeAction<String>> actionsFromD = _problem.Actions("d").Cast<EdgeAction<String>>().ToList();
            List<EdgeAction<String>> actionsFromE = _problem.Actions("e").Cast<EdgeAction<String>>().ToList();
            List<EdgeAction<String>> actionsFromF = _problem.Actions("f").Cast<EdgeAction<String>>().ToList();
            List<EdgeAction<String>> actionsFromG = _problem.Actions("g").Cast<EdgeAction<String>>().ToList();
            
            Assert.Equal(actionsFromA, new List<EdgeAction<String>>{
                new EdgeAction<String>(new Edge<String>("a","c",1)),
                new EdgeAction<String>(new Edge<String>("a","d",1)) } );
            Assert.Equal(actionsFromB, new List<EdgeAction<String>>{
                new EdgeAction<String>(new Edge<String>("b","c",1)),
                new EdgeAction<String>(new Edge<String>("b","e",1)) } );
            Assert.Equal(actionsFromC, new List<EdgeAction<String>>{
                new EdgeAction<String>(new Edge<String>("c","a",1)),
                new EdgeAction<String>(new Edge<String>("c","b",1)) } );
            Assert.Equal(actionsFromD, new List<EdgeAction<String>>{
                new EdgeAction<String>(new Edge<String>("d","a",1)),
                new EdgeAction<String>(new Edge<String>("d","g",1)) } );
            Assert.Equal(actionsFromE, new List<EdgeAction<String>>{
                new EdgeAction<String>(new Edge<String>("e","b",1)),
                new EdgeAction<String>(new Edge<String>("e","f",1)) } );
             Assert.Equal(actionsFromF, new List<EdgeAction<String>>{
                new EdgeAction<String>(new Edge<String>("f","e",1)),
                new EdgeAction<String>(new Edge<String>("f","g",1)) } );
            Assert.Equal(actionsFromG, new List<EdgeAction<String>>{
                new EdgeAction<String>(new Edge<String>("g","d",1)),
                new EdgeAction<String>(new Edge<String>("g","f",1)) } );
        }

        [Fact]
        public void BfsWhenFrontierLifoQueue()
        {
            IFrontier<Node<String>> frontier = new LifoQueue<Node<string>>();
            UninformedSearch<String> bfsSearch = new UninformedSearch<string>(_problem, frontier);
            SearchResult<String> searchResult = bfsSearch.Search();

            List<String> states = searchResult.States.ToList();
            List<EdgeAction<String>> actions = searchResult.Actions.Cast<EdgeAction<String>>().ToList();
            
            Assert.Equal(states, new List<String>{"e", "b", "c", "a"});

            Assert.Equal(actions, new List<EdgeAction<String>>{
                new EdgeAction<String>(new Edge<String>("b","e",1)),
                new EdgeAction<String>(new Edge<String>("c","b",1)),
                new EdgeAction<String>(new Edge<String>("a","c",1)),
                null} );
        
            Assert.Equal(3, searchResult.Cost);
            Assert.Equal(4, bfsSearch.ClosedList.Count);
            Assert.Equal(5, bfsSearch.OpenList.Count);
        }


        [Fact]
        public void DfsWhenFrontierFifoQueue()
        {
            IFrontier<Node<String>> frontier = new FifoQueue<Node<string>>();
            UninformedSearch<String> dfsSearch = new UninformedSearch<string>(_problem, frontier);
            SearchResult<String> searchResult = dfsSearch.Search();

            List<String> states = searchResult.States.ToList();
            List<EdgeAction<String>> actions = searchResult.Actions.Cast<EdgeAction<String>>().ToList();
            
            Assert.Equal(states, new List<String>{"e", "f", "g", "d", "a"});

            Assert.Equal(actions, new List<EdgeAction<String>>{
                new EdgeAction<String>(new Edge<String>("f","e",1)),
                new EdgeAction<String>(new Edge<String>("g","f",1)),
                new EdgeAction<String>(new Edge<String>("d","g",1)),
                new EdgeAction<String>(new Edge<String>("a","d",1)),
                null} );
        
            Assert.Equal(searchResult.Cost, 4);
            Assert.Equal(4, dfsSearch.ClosedList.Count);
            Assert.Equal(5, dfsSearch.OpenList.Count);
        }
    }
}