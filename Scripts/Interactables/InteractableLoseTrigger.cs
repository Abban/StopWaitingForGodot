using System;
using ClumsyCraig.Payload;
using Godot;

namespace ClumsyCraig.Interactables
{
    public class InteractableLoseTrigger : Area2D
    {
        public Action<CraigBody> OnBodyEntered = body => { };

        public void OnAreaEnter(CraigBody body)
        {
            if (body.Name == Config.ObjectNames.CraigBody)
            {
                OnBodyEntered.Invoke(body);
            }
        }
    }
}
