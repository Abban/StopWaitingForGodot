using System;
using System.Collections.Generic;

namespace ClumsyCraig.Modules.StateMachine
{
    public abstract class State : IState
    {
        protected readonly List<Type> CanMoveToStates = new List<Type>();
        protected Type FromState;


        /// <inheritdoc />
        public virtual void Start(Type lastState)
        {
            FromState = lastState;
        }

        /// <inheritdoc />
        public virtual void Update(float delta)
        {
        }


        /// <inheritdoc />
        public virtual void Exit()
        {
        }


        /// <inheritdoc />
        public bool CanMoveToState(Type type)
        {
            return CanMoveToStates.Contains(type);
        }
    }
}