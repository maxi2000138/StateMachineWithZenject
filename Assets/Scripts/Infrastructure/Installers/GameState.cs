using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States.IStates;
using Zenject;

namespace Infrastructure.Installers
{
    public class GameState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public GameState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
    
        public void Enter()
        {
        }

        public void Exit()
        {
            
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, GameState>
        {
        }
    }
}