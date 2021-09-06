using System;
using ClumsyCraig.Payload;
using Godot;

namespace ClumsyCraig.Player
{
    public class Craig : Node2D, IPayload
    {
        public Action<Config.EndGameTypes, Config.Parents> OnEndGameAction = (type, parent) => { };
        
        private Components _components;

        private enum MoveState
        {
            Stopped,
            Moving
        }

        private MoveState _moveState = MoveState.Stopped;

        public override void _Ready()
        {
            InitialiseComponents();
            InitialiseEventHandlers();
        }

        public override void _Process(float delta)
        {
            if (_moveState == MoveState.Moving)
            {
                _components.CraigPathFollow2D.Move(delta);
            }
        }

        private void OnWin()
        {
            OnEndGameAction.Invoke(Config.EndGameTypes.Win, Config.Parents.Dad);
        }

        private void OnLose(Config.EndGameTypes type, Config.Parents parent)
        {
            OnEndGameAction.Invoke(type, parent);
        }
        
        public void Start()
        {
            _moveState = MoveState.Moving;
        }

        public void Stop()
        {
            _moveState = MoveState.Stopped;
        }

        public void Reset()
        {
            Stop();
            _components.CraigPathFollow2D.Reset();
        }

        private void InitialiseComponents()
        {
            _components = new Components(
                GetNode<CraigPathFollow2D>("CraigPath/CraigPathFollow2D"),
                GetNode<CraigBody>("CraigPath/CraigPathFollow2D/CraigBody")
            );
        }

        private void InitialiseEventHandlers()
        {
            _components.CraigBody.WinAction += OnWin;
            _components.CraigBody.LoseAction += OnLose;
        }

        private class Components
        {
            public Components(
                CraigPathFollow2D craigPathFollow2D,
                CraigBody craigBody)
            {
                CraigPathFollow2D = craigPathFollow2D;
                CraigBody = craigBody;
            }

            public CraigPathFollow2D CraigPathFollow2D { get; }
            public CraigBody CraigBody { get; }
        }
    }
}