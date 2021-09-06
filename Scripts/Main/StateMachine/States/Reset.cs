using System;
using System.Collections.Generic;
using ClumsyCraig.Modules.StateMachine;

namespace ClumsyCraig.StateMachine.States
{
    public class Reset : State
    {
        private readonly List<IResettable> _resettables;
        private readonly Action<Type> _changeStateAction;

        public Reset(
            List<IResettable> resettables,
            Action<Type> changeStateAction)
        {
            _resettables = resettables;
            _changeStateAction = changeStateAction;

            CanMoveToStates.Add(LevelStates.Start);
        }


        public override void Start(Type lastState)
        {
            base.Start(lastState);
            _resettables.ForEach(resettable => resettable.Reset());
            _changeStateAction.Invoke(LevelStates.Start);
        }
    }
}