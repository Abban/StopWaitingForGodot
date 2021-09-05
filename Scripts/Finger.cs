using Godot;

namespace ClumsyCraig
{
    public class Finger : KinematicBody2D
    {
        private const int Speed = 500;
        
        private Vector2 _velocity = Vector2.Zero;

        public override void _PhysicsProcess(float delta)
        {
            GetInput();
            _velocity = MoveAndSlide(_velocity);
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

            _velocity = velocity.Normalized() * Speed;
        }
    }
}