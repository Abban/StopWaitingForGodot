using Godot;

namespace ClumsyCraig
{
    public class Main : Node
    {
        private Components _components;

    
        public override void _Ready()
        {
            InitialiseComponents();
        }


        private void InitialiseComponents()
        {
            _components = new Components(
                GetNode<PathFollow2D>("CraigPath/CraigPathFollow")
            );
        }


        public override void _Process(float delta)
        {
            _components.CraigPathFollow2D.Offset += 250 * delta;
        }

    
        private class Components
        {
            public PathFollow2D CraigPathFollow2D { get; }
            public Components(PathFollow2D craigPathFollow2D)
            {
                CraigPathFollow2D = craigPathFollow2D;
            }
        }
    }
}