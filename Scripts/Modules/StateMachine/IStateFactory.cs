using System;

namespace ClumsyCraig.Modules.StateMachine
{
    public interface IStateFactory
    {
        /// <summary>
        /// Get a new state for the state machine
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IState Get(Type type);
    }
}