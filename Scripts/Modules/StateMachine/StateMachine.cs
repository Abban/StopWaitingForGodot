using System;

namespace ClumsyCraig.Modules.StateMachine
{
    public class StateMachine : IStateMachine
    {
        private readonly IStateFactory _factory;
        public IState CurrentState { get; private set; }
        public Type LastStateType { get; private set; }


        public StateMachine(IStateFactory factory)
        {
            _factory = factory;
        }


        /// <inheritdoc />
        public virtual void ChangeState(Type type)
        {
            var state = _factory.Get(type);

            if (CurrentState == null)
            {
                CurrentState = state;
                CurrentState.Start(null);
                return;
            }

            if (!CurrentState.CanMoveToState(type))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(type),
                    type,
                    $"{CurrentState.GetType().Name} tried to move to {state.GetType().Name}"
                );
            }

            CurrentState.Exit();
            LastStateType = CurrentState.GetType();
            CurrentState = state;
            CurrentState.Start(LastStateType);
        }


        /// <inheritdoc />
        public virtual bool CurrentStateIs(Type type)
        {
            return CurrentState.GetType() == type;
        }


        /// <inheritdoc />
        public virtual bool LastStateWas(Type type)
        {
            return LastStateType == type;
        }
    }
}