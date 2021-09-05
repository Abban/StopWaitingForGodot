using Godot;

namespace ClumsyCraig
{
    public class PathFollow2DTest : Node
    {
        private PathFollow2D _pathFollow2D;
    
        public override void _Ready()
        {
            _pathFollow2D = GetNode<PathFollow2D>("Path2D/PathFollow2D");
        }

        public override void _Process(float delta)
        {
            _pathFollow2D.Offset += 250 * delta;
        }
    }
}