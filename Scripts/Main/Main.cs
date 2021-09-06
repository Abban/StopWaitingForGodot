using System;
using ClumsyCraig.GUI;
using ClumsyCraig.Modules.StateMachine;
using ClumsyCraig.Payload;
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
            InitialiseEventHandlers();

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
            _components.Craig.OnEndGameAction += OnEndGameAction;
        }


        private void OnEndGameAction(Config.EndGameTypes type, Config.Parents parent)
        {
            if (!_stateMachine.CurrentStateIs(LevelStates.Playing)) return;
            
            // TODO: Need more states for the pre-fail, like falling over etc
            switch (type)
            {
                case Config.EndGameTypes.Win:
                    _stateMachine.ChangeState(LevelStates.Win);
                    break;
                case Config.EndGameTypes.Noise when parent == Config.Parents.Dad:
                case Config.EndGameTypes.Spotted when parent == Config.Parents.Dad:
                case Config.EndGameTypes.Fall when parent == Config.Parents.Dad:
                    _stateMachine.ChangeState(LevelStates.LoseDad);
                    break;
                case Config.EndGameTypes.Noise when parent == Config.Parents.Mam:
                case Config.EndGameTypes.Spotted when parent == Config.Parents.Mam:
                case Config.EndGameTypes.Fall when parent == Config.Parents.Mam:
                    _stateMachine.ChangeState(LevelStates.LoseMam);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

    
        public class Components
        {
            public Craig Craig { get; }
            public IPayload CraigPayload => Craig;
            public IGUIScreen StartScreen { get; }
            public IGUIScreen WinScreen { get; }
            public IGUIScreen LoseScreenDad { get; }
            public IGUIScreen LoseScreenMam { get; }

            public Components(
                Craig craig, 
                IGUIScreen startScreen,
                IGUIScreen winScreen,
                IGUIScreen loseScreenDad,
                IGUIScreen loseScreenMam)
            {
                Craig = craig;
                StartScreen = startScreen;
                WinScreen = winScreen;
                LoseScreenDad = loseScreenDad;
                LoseScreenMam = loseScreenMam;
            }
        }
    }
}