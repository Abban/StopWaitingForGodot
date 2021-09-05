using System;

namespace ClumsyCraig.Modules.StateMachine
{
    public interface IStateMachineState
    {
        IState CurrentState { get; }
        Type LastStateType { get; }
    }
}