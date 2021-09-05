using ClumsyCraig.Modules.StateMachine;
using ClumsyCraig.StateMachine;

namespace ClumsyCraig
{
    public class LevelFactory
    {
        private readonly Main.Components _components;
        
        
        public LevelFactory(Main.Components components)
        {
            _components = components;
        }


        private IStateMachine _levelStateMachine;
        public IStateMachine LevelStateMachine => _levelStateMachine ??= new Modules.StateMachine.StateMachine(
            new LevelStateFactory(
                _components,
                state => LevelStateMachine.ChangeState(state)
            )
        );
    }
}