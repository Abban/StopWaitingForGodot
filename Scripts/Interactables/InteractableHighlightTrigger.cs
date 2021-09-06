using System;
using Godot;

namespace ClumsyCraig.Interactables
{
    public class InteractableHighlightTrigger : Area2D
    {
        public Action OnFingerAreaEntered = () => { };
        public Action OnFingerAreaExited = () => { };

        public void OnAreaEnter(Finger body)
        {
            if (body.Name == Config.ObjectNames.FingerBody)
            {
                OnFingerAreaEntered.Invoke();
            }
        }

        public void OnAreaExit(Finger body)
        {
            if (body.Name == Config.ObjectNames.FingerBody)
            {
                OnFingerAreaExited.Invoke();
            }
        }
    }
}
