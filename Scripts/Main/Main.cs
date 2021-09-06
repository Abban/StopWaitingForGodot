using System;
using System.Collections.Generic;
using ClumsyCraig.GUI;
using ClumsyCraig.Interactables;
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
                GetNode<Finger>("Finger"),
                GetNode<Interactable>("Interactables/ToyRobot"),
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
            public Finger Finger { get; }
            public Interactable ToyRobot { get; }
            public IGUIScreen StartScreen { get; }
            public IGUIScreen WinScreen { get; }
            public IGUIScreen LoseScreenDad { get; }
            public IGUIScreen LoseScreenMam { get; }
            public List<IResettable> Resettables => new List<IResettable>
            {
                Craig,
                Finger,
                ToyRobot
            };

            public Components(
                Craig craig, 
                Finger finger,
                Interactable toyRobot,
                IGUIScreen startScreen,
                IGUIScreen winScreen,
                IGUIScreen loseScreenDad,
                IGUIScreen loseScreenMam)
            {
                Craig = craig;
                Finger = finger;
                ToyRobot = toyRobot;
                StartScreen = startScreen;
                WinScreen = winScreen;
                LoseScreenDad = loseScreenDad;
                LoseScreenMam = loseScreenMam;
            }
        }
    }
}