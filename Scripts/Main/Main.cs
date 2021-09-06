using ClumsyCraig.GUI;
using ClumsyCraig.Modules.StateMachine;
using ClumsyCraig.Player;
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
                GetNode<Craig>("Craig"),
                GetNode<GUIScreen>("GameGUI/GUI/StartScreen"),
                GetNode<GUIScreen>("GameGUI/GUI/WinScreen"),
                GetNode<GUIScreen>("GameGUI/GUI/LoseScreenDad"),
                GetNode<GUIScreen>("GameGUI/GUI/LoseScreenMam")
            );
        }


        private void InitialiseEventHandlers()
        {
            // GetNode("Timer").Connect("timeout", this, nameof(_on_Timer_timeout)); 
        }

    
        public class Components
        {
            public IPayload CraigPayload { get; }
            public IGUIScreen StartScreen { get; }
            public IGUIScreen WinScreen { get; }
            public IGUIScreen LoseScreenDad { get; }
            public IGUIScreen LoseScreenMam { get; }

            public Components(
                IPayload craigPayload, 
                IGUIScreen startScreen,
                IGUIScreen winScreen,
                IGUIScreen loseScreenDad,
                IGUIScreen loseScreenMam)
            {
                CraigPayload = craigPayload;
                StartScreen = startScreen;
                WinScreen = winScreen;
                LoseScreenDad = loseScreenDad;
                LoseScreenMam = loseScreenMam;
            }
        }
    }
}