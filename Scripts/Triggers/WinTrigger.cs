using ClumsyCraig.Payload;
using Godot;

namespace ClumsyCraig.Triggers
{
    public class WinTrigger : Area2D
    {
        public void OnAreaEnter(CraigBody body)
        {
            if (body.Name == Config.ObjectNames.CraigBody)
            {
                body.OnWin();
            }
        }
    }
}
