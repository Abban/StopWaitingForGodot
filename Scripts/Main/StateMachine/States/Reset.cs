using System;
using ClumsyCraig.Modules.StateMachine;
using Godot;

namespace ClumsyCraig.StateMachine.States
{
    public class Reset : State
    {
        // TODO: Put PathFollow2D in a service wrapper
        private readonly PathFollow2D _craigFollowPath;

        public Reset(PathFollow2D craigFollowPath)
        {
            _craigFollowPath = craigFollowPath;
            
            CanMoveToStates.Add(LevelStates.Start);
        }


        public override void Start(Type lastState)
        {
            base.Start(lastState);
            _craigFollowPath.Offset = 0;
        }
    }
}