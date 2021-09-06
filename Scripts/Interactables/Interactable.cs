using ClumsyCraig.Payload;
using Godot;

namespace ClumsyCraig.Interactables
{
    public class Interactable : Node2D, IResettable
    {
        [Export] private string _viewFileName = string.Empty;
        [Export] private Config.EndGameTypes _endGameType = Config.EndGameTypes.Noise;
        [Export] private Config.Parents _parent = Config.Parents.Dad;
        
        private Components _components;
        private IInteractableView _interactableView;
        
        private enum States
        {
            Idle,
            Highlighted,
            Triggered,
            Nullified
        }

        private States _state = States.Idle;

        public override void _Ready()
        {
            InitialiseComponents();
            InitialiseEventHandlers();
            LoadView();
        }

        public override void _Process(float delta)
        {
            if (_state != States.Highlighted) return;

            if (Input.IsActionPressed(Config.Input.Select))
            {
                OnFingerClick();
            }
        }

        public void Reset()
        {
            _state = States.Idle;
            _interactableView.Reset();
        }

        private void OnFingerAreaEntered()
        {
            if (_state != States.Idle) return;
            
            _state = States.Highlighted;
            _interactableView.Select();
        }

        private void OnFingerAreaExited()
        {
            _state = States.Idle;
            _interactableView.Deselect();
        }

        private void OnFingerClick()
        {
            _state = States.Nullified;
            _interactableView.Nullify();
        }

        private void OnPayloadAreaEntered(CraigBody body)
        {
            if (_state == States.Nullified) return;
            
            _state = States.Triggered;
            body.OnLose(_endGameType, _parent);
        }

        private void InitialiseComponents()
        {
            _components = new Components(
                GetNode<InteractableHighlightTrigger>("HighlightTrigger"),
                GetNode<InteractableLoseTrigger>("LoseTrigger")
            );
        }

        private void InitialiseEventHandlers()
        {
            _components.InteractableHighlightTrigger.OnFingerAreaEntered += OnFingerAreaEntered;
            _components.InteractableHighlightTrigger.OnFingerAreaExited += OnFingerAreaExited;
            _components.InteractableLoseTrigger.OnBodyEntered += OnPayloadAreaEntered;
        }

        private void LoadView()
        {
            var viewScene = ResourceLoader.Load<PackedScene>($"res://Scenes/Interactables/{_viewFileName}.tscn");
            var view = viewScene.Instance();
            AddChild(view);
            _interactableView = view as IInteractableView;
        }

        private class Components
        {
            public Components(
                InteractableHighlightTrigger interactableHighlightTrigger,
                InteractableLoseTrigger interactableLoseTrigger)
            {
                InteractableHighlightTrigger = interactableHighlightTrigger;
                InteractableLoseTrigger = interactableLoseTrigger;
            }
        
            public InteractableHighlightTrigger InteractableHighlightTrigger { get; }
            public InteractableLoseTrigger InteractableLoseTrigger { get; }
        }
    }
}
