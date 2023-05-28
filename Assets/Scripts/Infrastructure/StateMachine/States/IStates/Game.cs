using Zenject;

namespace Infrastructure.StateMachine.States.IStates
{
    public class Game : IGame, IInitializable
    {
        private IGameStateMachine _stateMachine;

        public Game(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        // Entry point
        public void Initialize()
        {
            EnterState<BootstrapState>();
        }
        
        public void Restart()
        {
            EnterState<LoadLevelState>();
        }
        
        public void EnterState<TState>() where TState : StateBase
        {
            _stateMachine.Enter<TState>(this);
        }
    }
}