using System;
using System.Collections.Generic;
using TwoPlayerAi.Graphs;
using TwoPlayerAi.Search;

using TwoPlayerAi.AdjacencyMatrices;

namespace TwoPlayerAi.GraphProblems
{
    public class GraphProblem<T> : IProblem<T>
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

        public T InitialState
        {
            get
            {
                return _initialState;
            }
        }
        
        public T GoalState
        {
            get
            {
                return _goalState;
            }
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
}