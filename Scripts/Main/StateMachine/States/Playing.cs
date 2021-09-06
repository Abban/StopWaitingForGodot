using System;
using ClumsyCraig.Modules.StateMachine;
using ClumsyCraig.Payload;

namespace ClumsyCraig.StateMachine.States
{
    public class Playing : State
    {
        private readonly IPayload _payload;

        public Playing(IPayload payload)
        {
            _payload = payload;
            
            CanMoveToStates.Add(LevelStates.Win);
            CanMoveToStates.Add(LevelStates.LoseDad);
            CanMoveToStates.Add(LevelStates.LoseMam);
        }


        public override void Start(Type lastState)
        {
            base.Start(lastState);
            _payload.Start();
        }
    }
}