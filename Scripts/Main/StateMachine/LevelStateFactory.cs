using System;
using ClumsyCraig.Modules.StateMachine;
using ClumsyCraig.StateMachine.States;

namespace ClumsyCraig.StateMachine
{
    public class LevelStateFactory : IStateFactory
    {
        private readonly Main.Components _components;
        private Action<Type> _changeStateAction;

        public LevelStateFactory(
            Main.Components components,
            Action<Type> changeStateAction)
        {
            _components = components;
            _changeStateAction = changeStateAction;
        }

        public IState Get(Type type)
        {
            if (type == LevelStates.Start) return Start;
            if (type == LevelStates.Playing) return Playing;
            if (type == LevelStates.Win) return Win;
            if (type == LevelStates.Reset) return Reset;
            if (type == LevelStates.LoseDad) return LoseDad;
            if (type == LevelStates.LoseMam) return LoseMam;

            throw new ArgumentOutOfRangeException(nameof(type), type, "Type did not match LevelState");
        }


        private IState _start;

        private IState Start => _start ??= new StartScreen(
            _components.StartScreen,
            _changeStateAction
        );

        private IState _playing;

        private IState Playing => _playing ??= new Playing(
            _components.CraigPathFollow2D
        );

        private IState _win;

        private IState Win => _win ??= new Win(
            _components.WinScreen,
            _changeStateAction
        );

        private IState _reset;

        private IState Reset => _reset ??= new Reset(
            _components.CraigPathFollow2D
        );
        
        
        private IState _loseDad;

        private IState LoseDad => _loseDad ??= new LoseDad(
            _components.LoseScreenDad,
            _changeStateAction
        );
        
        private IState _loseMam;

        private IState LoseMam => _loseMam ??= new LoseMam(
            _components.LoseScreenMam,
            _changeStateAction
        );
    }
}