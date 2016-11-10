using System.Collections.Generic;

namespace TwoPlayerAi.Search
{
    public interface IProblem
    {
        IState InitialState();

        IEnumerable<IAction> Actions(IState state);

        IState Transition(IState state, IAction action);
        
        bool GoalTest(IState state);

        int StepCost(IState state, IAction action);
    }
}