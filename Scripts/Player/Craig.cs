using Godot;

namespace ClumsyCraig.Player
{
    public class Craig : Node2D, IPayload
    {
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
        }

        public override void _Process(float delta)
        {
            if (_moveState == MoveState.Moving)
            {
                _components.CraigPathFollow2D.Move(delta);
            }
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
                GetNode<CraigPathFollow2D>("CraigPath/CraigPathFollow2D")
            );
        }

        private class Components
        {
            public Components(CraigPathFollow2D craigPathFollow2D)
            {
                CraigPathFollow2D = craigPathFollow2D;
            }

            public CraigPathFollow2D CraigPathFollow2D { get; }
        }
    }
}