using System;
using ClumsyCraig.Modules.StateMachine;
using ClumsyCraig.Player;

namespace ClumsyCraig.StateMachine.States
{
    public class Reset : State
    {
        private readonly IPayload _payload;

        public Reset(IPayload payload)
        {
            _payload = payload;
            
            CanMoveToStates.Add(LevelStates.Start);
        }


        public override void Start(Type lastState)
        {
            base.Start(lastState);
            _payload.Reset();
        }
    }
}