using Godot;
using ClumsyCraig;
using ClumsyCraig.Payload;

public class InteractableLoseTrigger : Area2D
{
    [Export] private Config.EndGameTypes _endGameType = Config.EndGameTypes.Noise;
    [Export] private Config.Parents _parent = Config.Parents.Dad;

    public void OnAreaEnter(CraigBody body)
    {
        if (body.Name == Config.ObjectNames.CraigBody)
        {
            body.OnLose(_endGameType, _parent);
        }
    }
}
