using System;
using ClumsyCraig.GUI;
using ClumsyCraig.Modules.StateMachine;
using Godot;

namespace ClumsyCraig.StateMachine.States
{
    public class LoseDad : State
    {
        private readonly IGUIScreen _loseScreen;
        private readonly Action<Type> _changeStateAction;

        public LoseDad(
            IGUIScreen loseScreen,
            Action<Type> changeStateAction)
        {
            _loseScreen = loseScreen;
            _changeStateAction = changeStateAction;
        
            CanMoveToStates.Add(LevelStates.Reset);
        }


        public override void Start(Type lastState)
        {
            base.Start(lastState);
            _loseScreen.Show();
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
            _loseScreen.Hide();
        }
    }
}