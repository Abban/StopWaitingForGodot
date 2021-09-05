using System;
using ClumsyCraig.GUI;
using ClumsyCraig.Modules.StateMachine;
using Godot;

namespace ClumsyCraig.StateMachine.States
{
    public class Win : State
    {
        private readonly IGUIScreen _winScreen;
        private readonly Action<Type> _changeStateAction;

        public Win(
            IGUIScreen winScreen,
            Action<Type> changeStateAction)
        {
            _winScreen = winScreen;
            _changeStateAction = changeStateAction;
        
            CanMoveToStates.Add(LevelStates.Reset);
        }


        public override void Start(Type lastState)
        {
            base.Start(lastState);
            _winScreen.Show();
        }

        public override void Update(float delta)
        {
            // TODO: Put Input in a service wrapper
            if (Input.IsActionPressed(Config.Input.Select))
            {
                _changeStateAction.Invoke(LevelStates.Reset);
            }
        }


        public override void Exit()
        {
            _winScreen.Hide();
        }
    }
}