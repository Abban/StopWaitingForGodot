using Godot;

namespace ClumsyCraig
{
    public class Finger : KinematicBody2D, IResettable
    {
        private const int Speed = 500;
        private const float Acceleration = 0.1f;
        private const float Deceleration = 0.1f;
        
        private Vector2 _velocity = Vector2.Zero;
        private Vector2 _startPosition;

        public override void _Ready()
        {
            _startPosition = Position;
        }

        public override void _PhysicsProcess(float delta)
        {
            GetInput();
            MoveAndSlide(_velocity);
        }

        private void GetInput()
        {
            var velocity = Vector2.Zero;

            if (Input.IsActionPressed(Config.Input.Up))
            {
                velocity.y -= 1;
            }
            
            if (Input.IsActionPressed(Config.Input.Down))
            {
                velocity.y += 1;
            }
            
            if (Input.IsActionPressed(Config.Input.Right))
            {
                velocity.x += 1;
            }
            
            if (Input.IsActionPressed(Config.Input.Left))
            {
                velocity.x -= 1;
            }
            
            var input = velocity.Normalized();
            _velocity = new Vector2(
                LerpAxis(input.x, _velocity.x),
                LerpAxis(input.y, _velocity.y)
            );
        }
        
        
        private static float LerpAxis(float inputDirection, float currentVelocity)
        {
            if (inputDirection == 0)
            {
                return Mathf.Lerp(currentVelocity, 0, Deceleration);
            }

            return Mathf.Lerp(currentVelocity, inputDirection * Speed, Acceleration);
        }

        public void Reset()
        {
            Position = _startPosition;
        }
    }
}