using ClumsyCraig.GUI;
using ClumsyCraig.Modules.StateMachine;
using ClumsyCraig.StateMachine;
using Godot;

namespace ClumsyCraig
{
    // TODO: If this ever goes beyond a 1 scene game rename this to level or something as a real Main entrypoint will be needed  
    public class Main : Node
    {
        private Components _components;
        private LevelFactory _factory;
        private IStateMachine _stateMachine;

    
        public override void _Ready()
        {
            InitialiseComponents();

            _factory = new LevelFactory(_components);
            _stateMachine = _factory.LevelStateMachine;
            
            _stateMachine.ChangeState(LevelStates.Start);
        }


        public override void _Process(float delta)
        {
            _stateMachine.CurrentState.Update(delta);
        }
        
        
        private void InitialiseComponents()
        {
            _components = new Components(
                GetNode<PathFollow2D>("CraigPath/CraigPathFollow"),
                GetNode<GUIScreen>("GameGUI/GUI/StartScreen"),
                GetNode<GUIScreen>("GameGUI/GUI/WinScreen"),
                GetNode<GUIScreen>("GameGUI/GUI/LoseScreenDad"),
                GetNode<GUIScreen>("GameGUI/GUI/LoseScreenMam")
            );
        }

    
        public class Components
        {
            public PathFollow2D CraigPathFollow2D { get; }
            public IGUIScreen StartScreen { get; }
            public IGUIScreen WinScreen { get; }
            public IGUIScreen LoseScreenDad { get; }
            public IGUIScreen LoseScreenMam { get; }

            public Components(
                PathFollow2D craigPathFollow2D, 
                IGUIScreen startScreen,
                IGUIScreen winScreen,
                IGUIScreen loseScreenDad,
                IGUIScreen loseScreenMam)
            {
                CraigPathFollow2D = craigPathFollow2D;
                StartScreen = startScreen;
                WinScreen = winScreen;
                LoseScreenDad = loseScreenDad;
                LoseScreenMam = loseScreenMam;
            }
        }
    }
}