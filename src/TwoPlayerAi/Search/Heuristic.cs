using System;
using TwoPlayerAi.DataStructures;

namespace TwoPlayerAi.Search
{
    public class ManhattanDistanceHeuristic<T> : IHeustisticFunction<T>
        where T : Vector, IEquatable<T>
    {
        public int Calculate(IInformedProblem<T> problem, T state)
        {
            T goalState = problem.GoalState;
            return state.ManhattanDistance(goalState);

        }
    }

    public class DistanceHeuristic<T> : IHeustisticFunction<T>
        where T : Vector, IEquatable<T>
    {
        public int Calculate(IInformedProblem<T> problem, T state)
        {
            T goalState = problem.GoalState;
            return state.Distance(goalState);

        }
    }

    public class SquareDistanceHeuristic<T> : IHeustisticFunction<T>
        where T : Vector, IEquatable<T>
    {
        public int Calculate(IInformedProblem<T> problem, T state)
        {
            T goalState = problem.GoalState;
            return state.SquareDistance(goalState);

        }
    }

    public class DiagonalDistanceHeuristic<T> : IHeustisticFunction<T>
        where T : Vector, IEquatable<T>
    {
        public int Calculate(IInformedProblem<T> problem, T state)
        {
            T goalState = problem.GoalState;
            return state.DiagonalDistance(goalState);

        }
    }
}