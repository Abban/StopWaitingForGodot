using ClumsyCraig.Modules.StateMachine;
using Godot;

namespace ClumsyCraig.StateMachine.States
{
    public class Playing : State
    {
        // TODO: Put PathFollow2D in a service wrapper
        private readonly PathFollow2D _craigFollowPath;

        public Playing(PathFollow2D craigFollowPath)
        {
            _craigFollowPath = craigFollowPath;
            
            CanMoveToStates.Add(LevelStates.Win);
            CanMoveToStates.Add(LevelStates.LoseDad);
            CanMoveToStates.Add(LevelStates.LoseMam);
        }


        public override void Update(float delta)
        {
            _craigFollowPath.Offset += 250 * delta;
        }
    }
}