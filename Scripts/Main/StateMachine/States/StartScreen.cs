using System;
using ClumsyCraig;
using ClumsyCraig.GUI;
using ClumsyCraig.Modules.StateMachine;
using ClumsyCraig.StateMachine;
using Godot;

public class StartScreen : State
{
    private readonly IGUIScreen _startScreen;
    private readonly Action<Type> _changeStateAction;

    public StartScreen(
        IGUIScreen startScreen,
        Action<Type> changeStateAction)
    {
        _startScreen = startScreen;
        _changeStateAction = changeStateAction;
        
        CanMoveToStates.Add(LevelStates.Playing);
    }


    public override void Start(Type lastState)
    {
        base.Start(lastState);
        _startScreen.Show();
    }

    public override void Update(float delta)
    {
        // TODO: Put Input in a service wrapper
        if (Input.IsActionPressed(Config.Input.Select))
        {
            _changeStateAction.Invoke(LevelStates.Playing);
        }
    }


    public override void Exit()
    {
        _startScreen.Hide();
    }
}
