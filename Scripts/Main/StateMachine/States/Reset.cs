using System;
using ClumsyCraig.Modules.StateMachine;
using ClumsyCraig.Payload;

namespace ClumsyCraig.StateMachine.States
{
    public class Reset : State
    {
        private readonly IPayload _payload;
        private readonly Action<Type> _changeStateAction;

        public Reset(
            IPayload payload,
            Action<Type> changeStateAction)
        {
            _payload = payload;
            _changeStateAction = changeStateAction;

            CanMoveToStates.Add(LevelStates.Start);
        }


        public override void Start(Type lastState)
        {
            base.Start(lastState);
            _payload.Reset();
            _changeStateAction.Invoke(LevelStates.Start);
        }
    }
}